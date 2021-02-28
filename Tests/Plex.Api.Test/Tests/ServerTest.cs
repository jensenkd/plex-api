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

    public class ServerTest : TestBase
    {
        [Fact]
        public void Test_Plex_Server_InfoAsync()
        {
            var plexFactory = this.ServiceProvider.GetService<IPlexFactory>();

            // Get First Owned Server
            var servers = this.Account.GetAccountServersAsync().Result;
            var ownedServer = servers.First(c => c.Owned == 1);
            var fullUri = ownedServer.Host.ReturnUriFromServerInfo(ownedServer.Port, ownedServer.Scheme);

            var server = plexFactory.GetPlexServer(fullUri.ToString(), ownedServer.AccessToken);

            Assert.NotNull(server);
        }

        [Fact]
        public async void Test_GetPlexServerLibrarySummary()
        {
            var librarySummary = await this.Server.GetLibrarySummary();
            Assert.NotNull(librarySummary);
        }

        [Fact]
        public async void Test_GetPlexServerLibraryByKey()
        {
            const string key = "1";
            var filter = new LibraryFilter() {Keys = new List<string> {key}};
            var libraries = await this.Server.GetLibraries(filter);
            Assert.NotNull(libraries);
            Assert.Single(libraries);
            Assert.Equal(key, libraries[0].Key);
        }

        [Fact]
        public async void Test_GetPlexServerLibrariesByType()
        {
            const string type = "movie";
            var filter = new LibraryFilter() {Types = new List<string> {type}};
            var libraries = await this.Server.GetLibraries(filter);
            Assert.NotNull(libraries);
            foreach (var library in libraries)
            {
                Assert.Equal(type, libraries[0].Type);
            }
        }

        [Fact]
        public async void Test_GetPlexServerLibrariesByTitle()
        {
            const string title = "Movies";
            var filter = new LibraryFilter() {Titles = new List<string> {title}};
            var libraries = await this.Server.GetLibraries(filter);
            Assert.NotNull(libraries);
            foreach (var library in libraries)
            {
                Assert.Equal(title, libraries[0].Title);
            }
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
            const string libraryKey = "1";
            var items = await this.Server.GetHubRecentlyAdded(start, count);

            Assert.Equal(items.Media.Count, count);
        }
    }
}
