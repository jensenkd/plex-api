namespace Plex.Library.Test.Tests
{
    using Microsoft.Extensions.DependencyInjection;
    using ServerApi.Clients.Interfaces;
    using ServerApi.PlexModels.Library.Search;
    using Xunit;
    using Xunit.Abstractions;

    public class LibraryTest: IClassFixture<PlexFixture>
    {
        private readonly ITestOutputHelper output;
        private ServiceProvider serviceProvider;

        private readonly TestConfiguration config;
        private readonly IPlexServerClient plexServerClient;
        private readonly IPlexLibraryClient plexLibraryClient;

        public LibraryTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.serviceProvider = fixture.ServiceProvider;
            this.config = fixture.ServiceProvider.GetService<TestConfiguration>();
            this.plexServerClient = fixture.ServiceProvider.GetService<IPlexServerClient>();
            this.plexLibraryClient = fixture.ServiceProvider.GetService<IPlexLibraryClient>();
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
    }
}
