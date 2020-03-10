using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plex.Api.Models;
using Plex.Api.Models.Server;
using Plex.Api.Models.Status;

namespace Plex.Api.Tests.Tests
{
    [TestClass]
    public class AccountTests : TestBase
    {
        [TestMethod]
        public void Test_SignIn()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var login = Configuration.GetValue<string>("Plex:Login");
            var password = Configuration.GetValue<string>("Plex:Password");

            PlexAuthentication auth = plexApi
                .SignIn(new UserRequest{ Login = login, Password = password}).Result;

            Assert.IsNotNull(auth, $"Authentication Failed for {login}/{password}");
            Assert.AreEqual(auth.User.Email, login);
        }

        [TestMethod]
        public void Test_Get_Account()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var login = Configuration.GetValue<string>("Plex:Login");
            var password = Configuration.GetValue<string>("Plex:Password");

            PlexAuthentication auth = plexApi
                .SignIn(new UserRequest{ Login = login, Password = password}).Result;

            PlexAccount account = plexApi.GetAccount(auth.User.AuthenticationToken).Result;
            
            Assert.IsNotNull(auth, $"Authentication Failed for {login}/{password}");
            Assert.AreEqual(auth.User.Email, account.User.Email);
        }
        
        [TestMethod]
        public void Test_Get_Server()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var login = Configuration.GetValue<string>("Plex:Login");
            var password = Configuration.GetValue<string>("Plex:Password");

            PlexAuthentication auth = plexApi
                .SignIn(new UserRequest{ Login = login, Password = password}).Result;
            
            Models.Server.PlexServers account = plexApi.GetServers(auth.User.AuthenticationToken).Result;
            
            Assert.IsNotNull(auth, $"Authentication Failed for {login}/{password}");
            Assert.AreEqual("myPlex", account.FriendlyName);
        }
        
        [TestMethod]
        public void Test_Get_Server_Sessions()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var login = Configuration.GetValue<string>("Plex:Login");
            var password = Configuration.GetValue<string>("Plex:Password");

            PlexAuthentication auth = plexApi
                .SignIn(new UserRequest{ Login = login, Password = password}).Result;
            
            Models.Server.PlexServers account = plexApi.GetServers(auth.User.AuthenticationToken).Result;

            var fullUri = account.Server[0].Host.ReturnUriFromServerInfo(account.Server[0]);

            SessionWrapper sessions = plexApi.GetSessions(auth.User.AuthenticationToken, fullUri.ToString()).Result;
            
            Assert.IsNotNull(auth, $"Authentication Failed for {login}/{password}");
            Assert.AreEqual("myPlex", account.FriendlyName);
        }
    }
}