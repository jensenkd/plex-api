namespace Plex.Api.Test.Tests
{
    using System;
    using System.Globalization;
    using System.Linq;
    using PlexModels.Server.Releases;
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
            var servers = this.fixture.PlexAccount.Servers().Result;
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
        public async void Test_GetPlexServer_Activites()
        {
            var activities = await this.fixture.Server.Activities();

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
            if (updates.Size > 0)
            {
                foreach (var release in updates.Releases)
                {
                    this.output.WriteLine(release.Version);
                }
            }
            Assert.NotNull(updates);
        }

        [Fact]
        public async void Test_GetPlexServer_GetClients()
        {
            var items = await this.fixture.Server.Clients();
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_GetPlexServer_GetStatistics()
        {
            var items = await this.fixture.Server.Statistics();
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_PlexServerRefreshSyncList()
        {
            await this.fixture.Server.RefreshSyncList();
        }

        [Fact]
        public async void Test_PlexServerRefreshContent()
        {
            await this.fixture.Server.RefreshContent();
        }

        [Fact]
        public async void Test_PlexServerRefreshSync()
        {
            await this.fixture.Server.RefreshSync();
        }

        [Fact]
        public async void Test_GetPlexServer_GetDevices()
        {
            var items = await this.fixture.Server.Devices();
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_GetPlexServer_GetTranscodeSessions()
        {
            var items = await this.fixture.Server.TranscodeSessions();
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_GetPlexServer_GetSessions()
        {
            var items = await this.fixture.Server.Sessions();
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
        public async void Test_GetSessions()
        {
            var items = await this.fixture.Server.Sessions();
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_GetPlaylists()
        {
            var items = await this.fixture.Server.Playlists();
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
