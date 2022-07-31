namespace Plex.Library.Test.Tests
{
    using Microsoft.Extensions.DependencyInjection;
    using ServerApi.Clients.Interfaces;
    using Xunit;
    using Xunit.Abstractions;

    public class ServerTest: IClassFixture<PlexFixture>
    {
        private readonly ITestOutputHelper output;
        private ServiceProvider serviceProvider;

        private readonly TestConfiguration config;
        private readonly IPlexServerClient plexServerClient;
        private readonly IPlexLibraryClient plexLibraryClient;

        public ServerTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.serviceProvider = fixture.ServiceProvider;
            this.config = fixture.ServiceProvider.GetService<TestConfiguration>();
            this.plexServerClient = fixture.ServiceProvider.GetService<IPlexServerClient>();
            this.plexLibraryClient = fixture.ServiceProvider.GetService<IPlexLibraryClient>();
        }

        [Fact]
        public async void Test_GetServerInfo()
        {
            var server = await this.plexServerClient.GetPlexServerInfo(this.config.AuthenticationKey,
                this.config.Host);

            Assert.NotNull(server);
            Assert.True(server.Size > 0);
        }

        [Fact]
        public async void Test_GetPlayHistory()
        {
            var server = await this.plexServerClient.GetPlexServerInfo(this.config.AuthenticationKey,
                this.config.Host);

            var history = await this.plexServerClient.GetPlayHistory(this.config.AuthenticationKey,
                this.config.Host);


            Assert.NotNull(server);
            Assert.True(server.Size > 0);
        }

        [Fact]
        public async void Test_GetPosterArt()
        {
            var server = await this.plexServerClient.GetPlexServerInfo(this.config.AuthenticationKey,
                this.config.Host);

            var history = await this.plexServerClient.GetMediaPostersAsync(this.config.AuthenticationKey,
                this.config.Host, "288449");

            Assert.NotNull(server);
            Assert.True(server.Size > 0);
        }

    }
}
