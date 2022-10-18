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
        public async void Test_GetPlexServer_GetSessions()
        {
            var session = await this.plexServerClient.GetSessionsAsync(this.config.AuthenticationKey,
                this.config.Host);

            Assert.NotNull(session);
            Assert.True(session.Size > 0);
        }

        [Fact]
        public async void Test_GetPlexServer_GetSessionByPlayer()
        {
            const string playerKey = "jjmgbymh449v5jc7ip90sbj7";
            var session = await this.plexServerClient.GetSessionByPlayerIdAsync(this.config.AuthenticationKey,
                this.config.Host, playerKey);

            Assert.NotNull(session);
            Assert.True(session.Size > 0);
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
