namespace Plex.Api.Test.Tests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Helpers;
    using Microsoft.Extensions.DependencyInjection;
    using Plex.Api;
    using Xunit;

    public class AccountTest : TestBase
    {
        [Fact]
        public async Task Test_CreateOAuthPinAsync()
        {
            var redirectUrl = "http://test.com";
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();

            if (plexApi != null)
            {
                var result = await plexApi.CreateOAuthPinAsync(redirectUrl);

                Assert.Equal(
                    $"https://app.plex.tv/auth#?context[device][product]={this.ClientOptions.Product}&context[device][environment]=bundled&context[device][layout]=desktop&context[device][platform]={this.ClientOptions.Platform}&context[device][device]={this.ClientOptions.DeviceName}&clientID={this.ClientOptions.ClientId}&forwardUrl={redirectUrl}&code={result.Code}",
                    result.Url);

                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task Test_GetAccessTokenFromOAuthPinAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var pin = "XXX";
            if (plexApi != null)
            {
                var result1 = await plexApi.GetAuthTokenFromOAuthPinAsync(pin);
                Assert.NotNull(result1);
            }
        }

        [Fact]
        public async Task Test_SignInAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();

            var login = this.Configuration["Plex:Login"];
            var password = this.Configuration["Plex:Password"];

            if (plexApi != null)
            {
                var user = await plexApi
                    .SignInAsync(login, password);

                Assert.NotNull(user);
                Assert.Equal(user.Email, login);
            }
        }

        [Fact]
        public async Task Test_Get_AccountAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];
            if (plexApi != null)
            {
                var user = await plexApi.GetAccountAsync(authKey);
                Assert.NotNull(user.Email);
            }
        }

        [Fact]
        public async Task Test_Get_ResourcesAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];
            if (plexApi != null)
            {
                var resources = await plexApi.GetResourcesAsync(authKey);
                Assert.NotNull(resources);
            }
        }

        [Fact]
        public async Task Test_Get_ServerAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];

            if (plexApi != null)
            {
                var servers = await plexApi.GetServersAsync(authKey, false);
            }
        }

        [Fact]
        public async Task Test_Get_FriendsAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];

            if (plexApi != null)
            {
                var friends = await plexApi.GetFriendsAsync(authKey);

                Assert.NotNull(friends);
            }
        }

        [Fact]
        public async Task Test_Plex_InfoAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];

            if (plexApi != null)
            {
                var servers = await plexApi.GetServersAsync(authKey, false);

                var fullUri = servers[0].Host.ReturnUriFromServerInfo(servers[0]);

                var info = await plexApi.GetPlexInfoAsync(authKey, fullUri.ToString());

                Assert.NotNull(info);
            }
        }

        [Fact]
        public async Task Text_Plex_Server_Providers()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];

            if (plexApi != null)
            {
                var servers = await plexApi.GetServersAsync(authKey, false);

                var fullUri = servers[0].Host.ReturnUriFromServerInfo(servers[0]);

                var providers = await plexApi.GetServerProvidersAsync(authKey, fullUri.ToString());

                Assert.NotNull(providers);
            }
        }

        [Fact]
        public async Task Test_Get_Plex_Announcements()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];

            if (plexApi != null)
            {
                var announcements = await plexApi.GetPlexAnnouncementsAsync(authKey);

                Assert.NotNull(announcements);
            }
        }

        [Fact]
        public async Task Test_Get_Server_SessionsAsync()
        {
            var plexApi = this.ServiceProvider.GetService<IPlexClient>();
            var authKey = this.Configuration["Plex:AuthenticationKey"];

            if (plexApi != null)
            {
                var servers = await plexApi.GetServersAsync(authKey, false);

                var fullUri = servers[0].Host.ReturnUriFromServerInfo(servers[0]);

                var sessions = await plexApi.GetSessionsAsync(authKey, fullUri.ToString());

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
