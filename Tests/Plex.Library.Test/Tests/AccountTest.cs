namespace Plex.Library.Test.Tests
{
    using Microsoft.Extensions.DependencyInjection;
    using ServerApi.Clients.Interfaces;
    using ServerApi.Enums;
    using Xunit;
    using Xunit.Abstractions;

    public class AccountTest : IClassFixture<PlexFixture>
    {
        private readonly ITestOutputHelper output;
        private ServiceProvider serviceProvider;

        private readonly TestConfiguration config;
        private readonly IPlexAccountClient plexAccountClient;

        public AccountTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.serviceProvider = fixture.ServiceProvider;
            this.config = fixture.ServiceProvider.GetService<TestConfiguration>();
            this.plexAccountClient = fixture.ServiceProvider.GetService<IPlexAccountClient>();
        }

        [Fact]
        public async void Test_GetWatchlist()
        {
            var mediaContainer = await this.plexAccountClient.GetWatchList(this.config.AuthenticationKey, string.Empty, string.Empty, null);

            Assert.NotNull(mediaContainer);
        }

        [Fact]
        public async void Test_OnWatchlist()
        {
            const string ratingKey = "5d776b329ab5440021508861";
            var isOnWatchlist = await this.plexAccountClient.OnWatchlist(this.config.AuthenticationKey, ratingKey);

            Assert.True(isOnWatchlist);
        }

        [Fact]
        public async void Test_AddToWatchlist()
        {
            const string ratingKey = "5d776b329ab5440021508861";
            await this.plexAccountClient.AddToWatchlist(this.config.AuthenticationKey, ratingKey);
        }

        [Fact]
        public async void Test_RemoveFromWatchlist()
        {
            const string ratingKey = "5d776b329ab5440021508861";
            await this.plexAccountClient.RemoveFromWatchlist(this.config.AuthenticationKey, ratingKey);
        }

        [Fact]
        public async void Test_GetWatchlist_Shows_Only()
        {
            var mediaContainer = await this.plexAccountClient.GetWatchList(this.config.AuthenticationKey, string.Empty, string.Empty, SearchType.Show);

            foreach (var movie in mediaContainer.MediaContainers[0].Metadata)
            {
                Assert.Equal("show", movie.Type);
            }
        }

        [Fact]
        public async void Test_GetWatchlist_Movies_Only()
        {
            var mediaContainer = await this.plexAccountClient.GetWatchList(this.config.AuthenticationKey, string.Empty, string.Empty, SearchType.Movie);

            foreach (var movie in mediaContainer.MediaContainers[0].Metadata)
            {
                Assert.Equal("movie", movie.Type);
            }
        }

        [Fact]
        public async void Test_SearchDiscover()
        {
            var searchResults = await this.plexAccountClient.SearchDiscover(this.config.AuthenticationKey, "NBA");

            Assert.NotNull(searchResults);
        }
    }
}
