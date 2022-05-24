namespace Plex.Library.Test.Tests
{
    using Microsoft.Extensions.DependencyInjection;
    using ServerApi.Clients.Interfaces;
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
            var mediaContainer = await this.plexAccountClient.GetWatchList(this.config.AuthenticationKey, string.Empty, string.Empty, string.Empty);

            Assert.NotNull(mediaContainer);
        }

        [Fact]
        public async void Test_GetWatchlist_Shows_Only()
        {
            var mediaContainer = await this.plexAccountClient.GetWatchList(this.config.AuthenticationKey, string.Empty, string.Empty, "show");

            Assert.NotNull(mediaContainer);
        }

        [Fact]
        public async void Test_GetWatchlist_Movies_Only()
        {
            var mediaContainer = await this.plexAccountClient.GetWatchList(this.config.AuthenticationKey, string.Empty, string.Empty, "movie");

            Assert.NotNull(mediaContainer);
        }
    }
}
