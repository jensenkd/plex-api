namespace Plex.Api.Test
{
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using Plex.Api;
    using Xunit;

    public class AccountTest : TestBase
    {
        [Fact]
        public async System.Threading.Tasks.Task Test_CreateOAuthPinAsync()
        {
            var redirectUrl = "http://test.com";
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();

            if (plexApi != null)
            {
                var result = await plexApi.CreateOAuthPin(redirectUrl);

                Assert.Equal(
                    $"https://app.plex.tv/auth#?context[device][product]={this.ClientOptions.Product}&context[device][environment]=bundled&context[device][layout]=desktop&context[device][platform]={this.ClientOptions.Platform}&context[device][device]={this.ClientOptions.DeviceName}&clientID={this.ClientOptions.ClientId}&forwardUrl={redirectUrl}&code={result.Code}",
                    result.Url);

                Assert.NotNull(result);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_GetAccessTokenFromOAuthPinAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var pin = "XXX";
            if (plexApi != null)
            {
                var result1 = await plexApi.GetAuthTokenFromOAuthPin(pin);
                Assert.NotNull(result1);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_SignInAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();

            var login = this.Configuration["Plex:Login"];
            var password = this.Configuration["Plex:Password"];

            if (plexApi != null)
            {
                var user = await plexApi
                    .SignIn(login, password);

                Assert.NotNull(user);
                Assert.Equal(user.Email, login);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_Get_AccountAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];
            if (plexApi != null)
            {
                var user = await plexApi.GetAccount(authKey);
                Assert.NotNull(user.Email);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_Get_ResourcesAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];
            if (plexApi != null)
            {
                var resources = await plexApi.GetResources(authKey);
                Assert.NotNull(resources);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_Get_ServerAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];

            if (plexApi != null)
            {
                var servers = await plexApi.GetServers(authKey);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_Get_FriendsAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];

            if (plexApi != null)
            {
                var friends = await plexApi.GetFriends(authKey);

                Assert.NotNull(friends);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_Plex_InfoAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];

            if (plexApi != null)
            {
                var servers = await plexApi.GetServers(authKey);

                var fullUri = servers[0].Host.ReturnUriFromServerInfo(servers[0]);

                var info = await plexApi.GetPlexInfo(authKey, fullUri.ToString());

                Assert.NotNull(info);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_Get_Server_SessionsAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];

            if (plexApi != null)
            {
                var servers = await plexApi.GetServers(authKey);

                var fullUri = servers[0].Host.ReturnUriFromServerInfo(servers[0]);

                var sessions = await plexApi.GetSessions(authKey, fullUri.ToString());

                if (sessions != null && sessions.Any())
                {
                    var session = sessions
                        .FirstOrDefault(c => c.Player.MachineIdentifier == "mot82pjdqtmfsy7q2xkgj6hi");

                    Assert.NotNull(session);
                }
            }
        }
    }
}
