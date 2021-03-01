namespace Plex.Api.Test.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using Helpers;
    using Microsoft.Extensions.DependencyInjection;
    using PlexModels.Library;
    using Test;
    using Xunit;
    using Xunit.Abstractions;

    public class ServerTest : TestBase
    {
        private readonly ITestOutputHelper output;
        public ServerTest(ITestOutputHelper output) =>
            this.output = output;

        [Fact]
        public void Test_Plex_Server_InfoAsync()
        {
            var plexFactory = this.ServiceProvider.GetService<IPlexFactory>();

            // Get First Owned Server
            var servers = this.Account.Servers().Result;
            var ownedServer = servers.First(c => c.Owned == 1);
            var fullUri = ownedServer.Host.ReturnUriFromServerInfo(ownedServer.Port, ownedServer.Scheme);

            var server = plexFactory.GetPlexServer(fullUri.ToString(), ownedServer.AccessToken);

            Assert.NotNull(server);
        }

        [Fact]
        public async void Test_GetPlexServer_HubOnDeck()
        {
            const int start = 0;
            const int count = 3;
            var items = await this.Server.GetHomeOnDeck(start, count);

            Assert.Equal(items.Media.Count, count);
        }

        [Fact]
        public async void Test_GetPlexServer_HubContinueWatching()
        {
            const int start = 0;
            const int count = 3;
            var items = await this.Server.GetHubContinueWatching(start, count);

            Assert.Equal(items.Media.Count, count);
        }

        [Fact]
        public async void Test_GetPlexServer_HubRecentlyAdded()
        {
            const int start = 0;
            const int count = 3;
            var items = await this.Server.GetHubRecentlyAdded(start, count);

            Assert.Equal(items.Media.Count, count);
        }

        [Fact]
        public async void Test_GetPlexServer_GetPlayHistory()
        {
            const int start = 0;
            const int count = 3;
            var items = await this.Server.PlayHistory();

            Assert.NotNull(items);

        }

        [Fact]
        public async void Text_Plex_Server_Providers()
        {
            var providerContainer = await this.Server.GetProviders();
            foreach (var provider in providerContainer.Providers)
            {
                this.output.WriteLine("Provider: " + provider.Title);
                this.output.WriteLine(provider.Protocols);
                this.output.WriteLine(provider.Identifier);
                this.output.WriteLine(provider.Types);
                this.output.WriteLine(string.Empty);
            }
            Assert.NotNull(providerContainer);
        }
    }
}
