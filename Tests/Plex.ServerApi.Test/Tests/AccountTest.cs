namespace Plex.ServerApi.Test.Tests
{
    using System.Linq;
    using Clients.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using Xunit.Abstractions;

    public class AccountTest : IClassFixture<PlexFixture>
    {
        private readonly PlexFixture fixture;
        private readonly ITestOutputHelper output;

        public AccountTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.fixture = fixture;
        }

        [Fact]
        public void Test_GetPlexAccountByAuthToken()
        {
            var plexAccount = this.fixture.PlexFactory.GetPlexAccount(this.fixture.TestConfiguration.AccessToken);
            Assert.NotNull(plexAccount);
        }

        [Fact]
        public void Test_GetPlexAccount()
        {
            if (this.fixture.PlexFactory != null)
            {
                var plexAccount = this.fixture.PlexFactory.GetPlexAccount(this.fixture.TestConfiguration.Login, this.fixture.TestConfiguration.Password);
                Assert.NotNull(plexAccount);
            }
        }

        [Fact]
        public void Test_ValidPlexAccount()
        {
            Assert.NotNull(this.fixture.PlexAccount);
            this.output.WriteLine("Username: " + this.fixture.PlexAccount.Username);
            Assert.NotNull(this.fixture.PlexAccount.Username);
            Assert.NotEqual(string.Empty, this.fixture.PlexAccount.Username);
            this.output.WriteLine("AuthToken: " + this.fixture.PlexAccount.AuthToken);
            Assert.NotNull(this.fixture.PlexAccount.AuthToken);
            Assert.NotEqual(string.Empty, this.fixture.PlexAccount.AuthToken);
            this.output.WriteLine("Email: " + this.fixture.PlexAccount.Email);
            Assert.NotNull(this.fixture.PlexAccount.Email);
            Assert.NotEqual(string.Empty, this.fixture.PlexAccount.Email);
        }

        [Fact]
        public async void Test_GetAccessTokenFromOAuthPinAsync()
        {
            var plexAccountClient = this.fixture.ServiceProvider.GetService<IPlexAccountClient>();
            if (plexAccountClient != null)
            {
                var pin = await plexAccountClient.CreateOAuthPinAsync(string.Empty);

                var result1 = await plexAccountClient.LinkDeviceToAccountByPin(pin.Code);
                Assert.NotNull(result1);
            }
        }

        [Fact]
        public async void Test_SignInAsync()
        {
            var plexAccountClient = this.fixture.ServiceProvider.GetService<IPlexAccountClient>();
            if (plexAccountClient != null)
            {
                var user = await plexAccountClient.SignInAsync(this.fixture.TestConfiguration.Login,
                    this.fixture.TestConfiguration.Password);

                Assert.NotNull(user);
                Assert.Equal(user.Email, this.fixture.TestConfiguration.Login);
            }
        }

        [Fact]
        public async void Test_CreateOAuthPinAsync()
        {
            const string redirectUrl = "www.test.com";
            var result = await this.fixture.PlexAccount.CreatePin(redirectUrl);

            Assert.Equal(
                $"https://app.plex.tv/auth#?context[device][product]={this.fixture.TestConfiguration.ClientOptions.Product}&context[device][environment]=bundled&context[device][layout]=desktop&context[device][platform]={this.fixture.TestConfiguration.ClientOptions.Platform}&context[device][device]={this.fixture.TestConfiguration.ClientOptions.DeviceName}&clientID={this.fixture.TestConfiguration.ClientOptions.ClientId}&forwardUrl={redirectUrl}&code={result.Code}",
                result.Url);

            Assert.NotNull(result);
        }

        [Fact]
        public void Test_PlexAccountSubscription()
        {
            Assert.True(this.fixture.PlexAccount.Subscription.Active, "Subscription is not active");
            Assert.Equal("Active", this.fixture.PlexAccount.Subscription.Status);
            Assert.NotNull(this.fixture.PlexAccount.Subscription.Plan);
            Assert.Contains("premium_music_metadata", this.fixture.PlexAccount.Subscription.Features);
            Assert.Contains("sync", this.fixture.PlexAccount.Subscription.Features);
            Assert.Contains("plexpass", this.fixture.PlexAccount.Roles);
        }

        [Fact]
        public async void Test_GetPlexAccountServers()
        {
            this.output.WriteLine("Username: " + this.fixture.PlexAccount.Username);
            Assert.NotNull(this.fixture.PlexAccount.Username);
            Assert.NotEqual(string.Empty, this.fixture.PlexAccount.Username);
            this.output.WriteLine("AuthToken: " + this.fixture.PlexAccount.AuthToken);
            Assert.NotNull(this.fixture.PlexAccount.AuthToken);
            Assert.NotEqual(string.Empty, this.fixture.PlexAccount.AuthToken);
            this.output.WriteLine("Email: " + this.fixture.PlexAccount.Email);
            Assert.NotNull(this.fixture.PlexAccount.Email);
            Assert.NotEqual(string.Empty, this.fixture.PlexAccount.Email);
            foreach (var server in await this.fixture.PlexAccount.Servers())
            {
                this.output.WriteLine("Server Name: " + server.FriendlyName);
                this.output.WriteLine("Server Host: " + server.Uri);
            }
        }

        [Fact]
        public async void Test_GetPlexAccountWatchlist()
        {
            this.output.WriteLine("Username: " + this.fixture.PlexAccount.Username);

            var watchlist = await this.fixture.PlexAccount.Watchlist(string.Empty, string.Empty, string.Empty);

            Assert.NotEmpty(watchlist);
        }

        [Fact]
        public async void Test_GetPlexAccountWatchlist_ShowsOnly()
        {
            this.output.WriteLine("Username: " + this.fixture.PlexAccount.Username);
            Assert.NotNull(this.fixture.PlexAccount.Username);
            Assert.NotEqual(string.Empty, this.fixture.PlexAccount.Username);
            this.output.WriteLine("AuthToken: " + this.fixture.PlexAccount.AuthToken);
            Assert.NotNull(this.fixture.PlexAccount.AuthToken);
            Assert.NotEqual(string.Empty, this.fixture.PlexAccount.AuthToken);
            this.output.WriteLine("Email: " + this.fixture.PlexAccount.Email);
            Assert.NotNull(this.fixture.PlexAccount.Email);
            Assert.NotEqual(string.Empty, this.fixture.PlexAccount.Email);
            foreach (var server in await this.fixture.PlexAccount.Servers())
            {
                this.output.WriteLine("Server Name: " + server.FriendlyName);
                this.output.WriteLine("Server Host: " + server.Uri);
            }
        }

        [Fact]
        public async void Test_Get_Resources()
        {
            var resourceContainer = await this.fixture.PlexAccount.Resources();
             foreach (var resource in resourceContainer.Resources)
             {
                 var name = string.IsNullOrEmpty(resource.Name) ? "Unkown" : resource.Name;
                 if (resource.Connections.Any())
                 {
                     var connections = string.Join(",", resource.Connections.Select(c => c.Uri.ToString()));
                     this.output.WriteLine($"{name} ({resource.Product}): {connections}");
                 }
                 else
                 {
                     this.output.WriteLine("No Connections");
                 }
            }
            Assert.NotNull(resourceContainer);
        }

        [Fact]
        public async void Test_Get_FriendsAsync()
        {
            var friends = await this.fixture.PlexAccount.Friends();
            Assert.NotNull(friends);
        }

        [Fact]
        public async void Test_Get_UsersAsync()
        {
            var users = await this.fixture.PlexAccount.Users();
            Assert.NotNull(users);
        }

        [Fact]
        public async void Test_Get_Plex_Announcements()
        {
            var announcements = await this.fixture.PlexAccount.Announcements();
            Assert.NotNull(announcements);
        }

        [Fact]
        public async void Test_Get_Plex_Devices()
        {
            var devices = await this.fixture.PlexAccount.Devices();
            Assert.NotNull(devices);
        }

        [Fact]
        public async void Test_Get_Plex_ServerSummaries()
        {
            var container = await this.fixture.PlexAccount.ServerSummaries();
            Assert.NotNull(container);
        }

        [Fact]
        public async void Test_Opt_Out()
        {
            const bool optOutOfPlayback = true;
            const bool optOutOfLibrary = true;
            await this.fixture.PlexAccount.OptOut(optOutOfPlayback, optOutOfLibrary);
        }

        // [Fact]
        // public async Task Test_Get_Server_SessionsAsync()
        // {
        //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
        //     var authKey = this.Configuration["Plex:AuthenticationKey"];
        //
        //     if (plexApi != null)
        //     {
        //         var servers = await plexApi.GetServersAsync(authKey, false);
        //
        //         var fullUri = servers[0].Host.ReturnUriFromServerInfo(servers[0]);
        //
        //         var sessions = await plexApi.GetSessionsAsync(authKey, fullUri.ToString());
        //
        //         if (sessions != null && sessions.Any())
        //         {
        //             var session = sessions
        //                 .FirstOrDefault(c => c.Player.MachineIdentifier == "mot82pjdqtmfsy7q2xkgj6hi");
        //
        //             Assert.NotNull(session);
        //         }
        //     }
        // }
    }
}
