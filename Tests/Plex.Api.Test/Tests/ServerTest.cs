namespace Plex.Api.Test.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Factories;
    using Helpers;
    using Microsoft.Extensions.DependencyInjection;
    using PlexModels.Library;
    using Test;
    using Xunit;
    using Xunit.Abstractions;

    public class ServerTest: IClassFixture<PlexFixture>
    {
        private readonly PlexFixture fixture;
        private readonly ITestOutputHelper output;

        public ServerTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.fixture = fixture;
        }

        [Fact]
        public void Test_Plex_Server_InfoAsync()
        {
            var plexFactory = this.fixture.ServiceProvider.GetService<IPlexFactory>();

            // Get First Owned Server
            var servers = this.fixture.Account.Servers().Result;
            var ownedServer = servers.First(c => c.Owned == 1);

            Assert.NotNull(ownedServer);
        }

        [Fact]
        public async void Test_GetPlexServer_HubOnDeck()
        {
            const int start = 0;
            const int count = 3;
            var items = await this.fixture.Server.HomeOnDeck(start, count);

            Assert.Equal(items.Media.Count, count);
        }

        [Fact]
        public async void Test_GetPlexServer_HubContinueWatching()
        {
            const int start = 0;
            const int count = 3;
            var items = await this.fixture.Server.HomeHubContinueWatching(start, count);

            Assert.Equal(items.Media.Count, count);
        }

        [Fact]
        public async void Test_GetPlexServer_DownloadLogs()
        {
           // var logs = await this.fixture.Server.DownloadLogs();
        }

        [Fact]
        public async void Test_GetPlexServer_CheckForUpdate()
        {
            var updates = await this.fixture.Server.CheckForUpdate();
            Assert.NotNull(updates);
        }

        [Fact]
        public async void Test_GetPlexServer_GetClients()
        {
            var items = await this.fixture.Server.Clients();
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_GetPlexServer_GetDevices()
        {
            var items = await this.fixture.Server.Devices();
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_GetPlexServer_HubRecentlyAdded()
        {
            const int start = 0;
            var items = await this.fixture.Server.HomeHubRecentlyAdded(start);

            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_GetPlexServer_GetPlayHistory()
        {
            const int start = 0;
            const int count = 13;
            var items = await this.fixture.Server.PlayHistory(start, count);

            foreach (var item in items.HistoryMetadata)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine(item.Type);
                this.output.WriteLine(DateTimeOffset.FromUnixTimeSeconds(item.ViewedAt).DateTime.ToString(CultureInfo.InvariantCulture));
                this.output.WriteLine(string.Empty);
            }
            Assert.NotNull(items);
            Assert.Equal(count, items.HistoryMetadata.Count);
        }

        [Fact]
        public async void Test_HubSearchByName()
        {
            const string title = "Harry Potter";
            var items = await this.fixture.Server.HubLibrarySearch(title);
            Assert.NotNull(items);
        }

        [Fact]
        public async void Text_Plex_Server_Providers()
        {
            var providerContainer = await this.fixture.Server.Providers();
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

        [Fact]
        public async void Test_ScrobbleItemAsync()
        {
            const string ratingKey = "92712";
            await this.fixture.Server.ScrobbleItem(ratingKey);
        }

        [Fact]
        public async void Test_UnscrobbleItemAsync()
        {
            const string ratingKey = "92712";
            await this.fixture.Server.UnScrobbleItem(ratingKey);
        }
    }
}
