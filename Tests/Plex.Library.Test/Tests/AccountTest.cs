namespace Plex.Library.Test.Tests
{
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using ServerApi.Clients.Interfaces;
    using ServerApi.Enums;
    using ServerApi.PlexModels.Account.SharedItems;
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
        public async void Test_GetAccountFriends()
        {
            var friends = await this.plexAccountClient.GetFriendsAsync(this.config.AuthenticationKey);

            Assert.NotEmpty(friends);
        }

        [Fact]
        public async void Test_GetHomeUsers()
        {
            var homeUserContainer = await this.plexAccountClient.GetHomeUsersAsync(this.config.AuthenticationKey);

            Assert.NotNull(homeUserContainer);
        }

        [Fact]
        public async void Test_GetWatchlist()
        {
            var mediaContainer = await this.plexAccountClient.GetWatchListAsync(this.config.AuthenticationKey, string.Empty, string.Empty, null);

            Assert.NotNull(mediaContainer);
        }

        [Fact]
        public async void Test_GetAccountSharedItems()
        {
            var sharedItems = await this.plexAccountClient.GetSharedItemsAsync(this.config.AuthenticationKey);
            Assert.NotEmpty(sharedItems);
        }


        [Fact]
        public async void Test_RemoveSharedItem()
        {
            const int sharedItemId = 30279190;
            await this.plexAccountClient.RemoveSharedItemAsync(this.config.AuthenticationKey, sharedItemId);
        }

        [Fact]
        public async void Test_AddSharedItem()
        {
            var request = new List<SharedItemModelRequest>
            {
                new()
                {
                    Uri = "server://31a76d623a6ec28b1619bd7679650d84d9552728/com.plexapp.plugins.library/library/metadata/350061",
                    Title = "The Northman",
                    Type = "movie"
                }
            };

            await this.plexAccountClient.AddSharedItemsAsync(this.config.AuthenticationKey, 20071940, request);
        }

        [Fact]
        public async void Test_OnWatchlist()
        {
            const string ratingKey = "5d776b329ab5440021508861";
            var isOnWatchlist = await this.plexAccountClient.OnWatchlistAsync(this.config.AuthenticationKey, ratingKey);

            Assert.True(isOnWatchlist);
        }

        [Fact]
        public async void Test_AddToWatchlist()
        {
            const string ratingKey = "5d776b329ab5440021508861";
            await this.plexAccountClient.AddToWatchlistAsync(this.config.AuthenticationKey, ratingKey);
        }

        [Fact]
        public async void Test_RemoveFromWatchlist()
        {
            const string ratingKey = "5d776b329ab5440021508861";
            await this.plexAccountClient.RemoveFromWatchlistAsync(this.config.AuthenticationKey, ratingKey);
        }

        [Fact]
        public async void Test_GetWatchlist_Shows_Only()
        {
            var mediaContainer = await this.plexAccountClient.GetWatchListAsync(this.config.AuthenticationKey, string.Empty, string.Empty, SearchType.Show);

            foreach (var movie in mediaContainer.MediaContainers[0].Metadata)
            {
                Assert.Equal("show", movie.Type);
            }
        }

        [Fact]
        public async void Test_GetWatchlist_Movies_Only()
        {
            var mediaContainer = await this.plexAccountClient.GetWatchListAsync(this.config.AuthenticationKey, string.Empty, string.Empty, SearchType.Movie);

            foreach (var movie in mediaContainer.MediaContainers[0].Metadata)
            {
                Assert.Equal("movie", movie.Type);
            }
        }

        [Fact]
        public async void Test_SearchDiscover()
        {
            var searchResults = await this.plexAccountClient.SearchDiscoverAsync(this.config.AuthenticationKey, "NBA");

            Assert.NotNull(searchResults);
        }
    }
}
