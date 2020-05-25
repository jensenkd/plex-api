using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Plex.Api.Models;
using Plex.Api.Models.Friends;
using Plex.Api.Models.Server;
using Plex.Api.Models.Status;

namespace Plex.Api.Tests.Tests
{
    [TestClass]
    public class AccountTests : TestBase
    {
        [TestMethod]
        public void Test_CreateAndGetOAuthPin()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();
            var result1 = plexApi.CreatePin().Result;

            string product = "";
            string platform = "";
            string device = "";
            string clientId = "";
            string redirectUrl = "";

            string url =
                $"https://app.plex.tv/auth#?context[device][product]={product}&context[device][environment]=bundled&context[device][layout]=desktop&context[device][platform]={platform}&context[device][device]={device}&clientID={clientId}&forwardUrl={redirectUrl}&code={result1.Code}";

            Assert.IsNotNull(result1);
        }

        [TestMethod]
        public void Test_SignIn()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var login = Configuration.GetValue<string>("Plex:Login");
            var password = Configuration.GetValue<string>("Plex:Password");

            User user = plexApi
                .SignIn(login, password).Result;

            Assert.IsNotNull(user, $"Authentication Failed for {login}/{password}");
            Assert.AreEqual(user.Email, login);
        }

        [TestMethod]
        public void Test_Get_Account()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");

            User user = plexApi.GetAccount(authKey).Result;
            
            Assert.IsNotNull(user.Email);
        }
        
        [TestMethod]
        public void Test_Get_Server()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");
            
            List<Server> servers = plexApi.GetServers(authKey).Result;
            
        }
        
        [TestMethod]
        public void Test_Get_Friends()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");
            
            List<Friend> friends = plexApi.GetFriends(authKey).Result;
            
            Assert.IsNotNull(friends);
        }

        [TestMethod]
        public void Test_Plex_Info()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");

            List<Server> servers = plexApi.GetServers(authKey).Result;

            var fullUri = servers[0].Host.ReturnUriFromServerInfo(servers[0]);

            
            var info = plexApi.GetPlexInfo(authKey, fullUri.ToString()).Result;

            Assert.IsNotNull(info);
        }

        [TestMethod]
        public void Test_Get_Server_Sessions()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");

            List<Server> servers = plexApi.GetServers(authKey).Result;

            var fullUri = servers[0].Host.ReturnUriFromServerInfo(servers[0]);

            List<Session> sessions = plexApi.GetSessions(authKey, fullUri.ToString()).Result;

            if (sessions != null && sessions.Any())
            {
                Session session = sessions
                    .FirstOrDefault(c => c.Player.MachineIdentifier == "mot82pjdqtmfsy7q2xkgj6hi");
            
                Assert.IsNotNull(session);
            }
        }
    }
}