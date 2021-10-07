namespace Plex.Library.Test.Tests
{
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using ServerApi.Clients.Interfaces;
    using ServerApi.PlexModels.Library.Search;
    using ServerApi.PlexModels.PlayQueues;
    using Xunit;
    using Xunit.Abstractions;

    public class LibraryTest : IClassFixture<PlexFixture>
    {
        private readonly ITestOutputHelper output;
        private ServiceProvider serviceProvider;

        private readonly TestConfiguration config;
        private readonly IPlexServerClient plexServerClient;
        private readonly IPlexLibraryClient plexLibraryClient;
        private readonly IPlexAccountClient plexAccountClient;

        public LibraryTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.serviceProvider = fixture.ServiceProvider;
            this.config = fixture.ServiceProvider.GetService<TestConfiguration>();
            this.plexServerClient = fixture.ServiceProvider.GetService<IPlexServerClient>();
            this.plexLibraryClient = fixture.ServiceProvider.GetService<IPlexLibraryClient>();
            this.plexAccountClient = fixture.ServiceProvider.GetService<IPlexAccountClient>();
        }

        [Fact]
        public async void Test_GetCollectionItems()
        {
            const string collectionKey = "112898";

            var mediaContainer = await this.plexLibraryClient.GetCollectionItemsAsync(this.config.AuthenticationKey,
                this.config.Host,
                collectionKey);

            Assert.NotNull(mediaContainer);
            Assert.True(mediaContainer.Size > 0);
        }

        [Fact]
        public async void Test_GetEpisodesForShow()
        {
            var filters = new Filter();
        }

        [Fact]
        public async void Test_GetChildrenMetadata()
        {
            const int ratingKey = 92640;

            var mediaContainer =
                await this.plexServerClient.GetChildrenMetadataAsync(this.config.AuthenticationKey,
                    this.config.Host, ratingKey);

            Assert.NotNull(mediaContainer);
            Assert.True(mediaContainer.Size > 0);
        }

        [Fact]
        public async void Test_GetExtrasForItem()
        {
            const string ratingKey = "9962";

            var extrasContainer =
                await this.plexLibraryClient.GetExtras(this.config.AuthenticationKey,
                    this.config.Host, ratingKey);

            Assert.NotNull(extrasContainer);
            Assert.True(extrasContainer.Size > 0);
        }

        [Fact]
        public async void Test_GetSessionForPlayer()
        {
            const string playerId = "14vcldig9owi1e8dljnt68z3";

            var sessionContainer =
                await this.plexServerClient.GetSessionByPlayerIdAsync(this.config.AuthenticationKey,
                    this.config.Host, playerId);

            Assert.NotNull(sessionContainer);
            Assert.True(sessionContainer.Size > 0);
        }

        [Fact]
        public async void Test_GetGrandChildrenMetadata()
        {
            const int ratingKey = 92640;

            var seasonsContainer =
                await this.plexServerClient.GetChildrenMetadataAsync(this.config.AuthenticationKey,
                    this.config.Host, ratingKey);

            Assert.NotNull(seasonsContainer);
            Assert.True(seasonsContainer.Size > 0);

            foreach (var season in seasonsContainer.Media)
            {
                var episodeContainer =
                    await this.plexServerClient.GetChildrenMetadataAsync(this.config.AuthenticationKey,
                        this.config.Host, int.Parse(season.RatingKey));

                Assert.NotNull(episodeContainer);
                Assert.True(episodeContainer.Size > 0);
            }
        }

        [Fact]
        public async void Test_PlayMediaItem()
        {
            const string type = "video";
            const string key = "207589";

            var server = await this.plexServerClient.GetPlexServerInfo(this.config.AuthenticationKey,
                this.config.Host);

            var playQueueContainer =
                await this.plexLibraryClient.CreatePlayQueue(this.config.AuthenticationKey,
                    this.config.Host, server.MachineIdentifier, type, key, false, false, true);

            Assert.NotNull(playQueueContainer);
            Assert.True(playQueueContainer.Size > 0);

            // 1. Get All Active Resources tied to Plex Account
            var resourceContainer = await this.plexAccountClient.GetResourcesAsync(this.config.AuthenticationKey);

            // 2. Get Server we want to use
            var plexServer = resourceContainer.Resources
                .First(c => c.Name == "Plex Media Server" && c.Provides.Contains("server"));

            // 3. Get Transient Token from Server
            var token = await this.plexServerClient.GetTransientToken(this.config.AuthenticationKey,
                this.config.Host);

            // 4. Get List of players that support 'player'.
            var players = resourceContainer.Resources
                .Where(c => c.Provides.Contains("player"));

            // 5. Get Player by name
            var player = players.First(c => c.Name == "Galaxy S9+");

            // 6. Send Playqueue to player
            await this.plexLibraryClient.SendPlayQueueToPlayer(this.config.Host, this.config.AuthenticationKey,
                server.MachineIdentifier, playQueueContainer, type, player.ClientIdentifier, token.Token, 50000);
        }
    }
}
