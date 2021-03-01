namespace Plex.Api.Test.Tests
{
    using System.Linq;
    using Clients;
    using Factories;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using Xunit.Abstractions;

    public class AccountTest : TestBase
    {
        private readonly ITestOutputHelper output;
        public AccountTest(ITestOutputHelper output) =>
            this.output = output;

        [Fact]
        public void Test_GetPlexAccountByAuthToken()
        {
            var authToken = this.Configuration["Plex:AuthenticationKey"];
            var plexFactory = this.ServiceProvider.GetService<IPlexFactory>();
            if (plexFactory != null)
            {
                var plexAccount = plexFactory.GetPlexAccount(authToken);
                Assert.NotNull(plexAccount);
            }
        }

        [Fact]
        public void Test_GetPlexAccount()
        {
            var login = this.Configuration["Plex:Login"];
            var password = this.Configuration["Plex:Password"];

            var plexFactory = this.ServiceProvider.GetService<IPlexFactory>();
            if (plexFactory != null)
            {
                var plexAccount = plexFactory.GetPlexAccount(login, password);
                Assert.NotNull(plexAccount);
            }
        }

        [Fact]
        public void Test_ValidPlexAccount()
        {
            Assert.NotNull(this.Account);
            this.output.WriteLine("Username: " + this.Account.Username);
            Assert.NotNull(this.Account.Username);
            Assert.NotEqual(string.Empty, this.Account.Username);
            this.output.WriteLine("AuthToken: " + this.Account.AuthToken);
            Assert.NotNull(this.Account.AuthToken);
            Assert.NotEqual(string.Empty, this.Account.AuthToken);
            this.output.WriteLine("Email: " + this.Account.Email);
            Assert.NotNull(this.Account.Email);
            Assert.NotEqual(string.Empty, this.Account.Email);
        }

        [Fact]
        public async void Test_GetAccessTokenFromOAuthPinAsync()
        {
            var pin = "XXX";

            var plexAccountClient = this.ServiceProvider.GetService<IPlexAccountClient>();
            if (plexAccountClient != null)
            {
                var result1 = await plexAccountClient.GetAuthTokenFromOAuthPinAsync(pin);
                Assert.NotNull(result1);
            }
        }

        [Fact]
        public async void Test_SignInAsync()
        {
            var login = this.Configuration["Plex:Login"];
            var password = this.Configuration["Plex:Password"];

            var plexAccountClient = this.ServiceProvider.GetService<IPlexAccountClient>();
            if (plexAccountClient != null)
            {
                var user = await plexAccountClient.SignInAsync(login, password);

                Assert.NotNull(user);
                Assert.Equal(user.Email, login);
            }
        }

        [Fact]
        public async void Test_CreateOAuthPinAsync()
        {
            const string redirectUrl = "www.test.com";
            var result = await this.Account.CreatePin(redirectUrl);

            Assert.Equal(
                $"https://app.plex.tv/auth#?context[device][product]={this.ClientOptions.Product}&context[device][environment]=bundled&context[device][layout]=desktop&context[device][platform]={this.ClientOptions.Platform}&context[device][device]={this.ClientOptions.DeviceName}&clientID={this.ClientOptions.ClientId}&forwardUrl={redirectUrl}&code={result.Code}",
                result.Url);

            Assert.NotNull(result);
        }

        [Fact]
        public void Test_PlexAccountSubscription()
        {
            Assert.True(this.Account.Subscription.Active, "Subscription is not active");
            Assert.Equal("Active", this.Account.Subscription.Status);
            Assert.NotNull(this.Account.Subscription.Plan);
            Assert.Contains("premium_music_metadata", this.Account.Subscription.Features);
            Assert.Contains("sync", this.Account.Subscription.Features);
            Assert.Contains("plexpass", this.Account.Roles);
        }

        [Fact]
        public async void Test_GetPlexAccountServers()
        {
            var plexServers = await this.Account.Servers();
            this.output.WriteLine("Username: " + this.Account.Username);
            Assert.NotNull(this.Account.Username);
            Assert.NotEqual(string.Empty, this.Account.Username);
            this.output.WriteLine("AuthToken: " + this.Account.AuthToken);
            Assert.NotNull(this.Account.AuthToken);
            Assert.NotEqual(string.Empty, this.Account.AuthToken);
            this.output.WriteLine("Email: " + this.Account.Email);
            Assert.NotNull(this.Account.Email);
            Assert.NotEqual(string.Empty, this.Account.Email);
            Assert.NotNull(plexServers);
            foreach (var server in plexServers)
            {
                this.output.WriteLine("Server Name: " + server.Name);
                this.output.WriteLine("Server Host: " + server.Host);
            }
        }

        [Fact]
        public async void Test_Get_ResourcesAsync()
        {
            var resources = await this.Account.Resources();
            foreach (var resource in resources)
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
            Assert.NotNull(resources);
        }

        [Fact]
        public async void Test_Get_FriendsAsync()
        {
            var friends = await this.Account.Friends();
            Assert.NotNull(friends);
        }

        [Fact]
        public async void Test_Get_UsersAsync()
        {
            var users = await this.Account.Users();
            Assert.NotNull(users);
        }

        [Fact]
        public async void Test_Get_Plex_Announcements()
        {
            var announcements = await this.Account.Announcements();
            Assert.NotNull(announcements);
        }

        [Fact]
        public async void Test_Get_Plex_Devices()
        {
            var devices = await this.Account.Devices();
            Assert.NotNull(devices);
        }

        [Fact]
        public async void Test_Opt_Out()
        {
            const bool optOutOfPlayback = true;
            const bool optOutOfLibrary = true;
            await this.Account.OptOut(optOutOfPlayback, optOutOfLibrary);
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
