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
        public void Test_CreateOAuthPin()
        {
            string redirectUrl = "http://test.com";
            var plexApi = ServiceProvider.GetService<IPlexClient>();
            var result1 = plexApi.CreateOAuthPin(redirectUrl).Result;

            var url = result1.Url;
            
            Assert.IsNotNull(result1);
        }
        
        [TestMethod]
        public void Test_GetAccessTokenFromOAuthPin()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();
            string pin = "XXX";
            var result1 = plexApi.GetAuthTokenFromOAuthPin(pin).Result;
            var token = result1.AuthToken;
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