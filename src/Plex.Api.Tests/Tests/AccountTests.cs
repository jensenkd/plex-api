using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plex.Api.Models;
using Plex.Api.Models.Server;

namespace Plex.Api.Tests.Tests
{
    [TestClass]
    public class AccountTests : TestBase
    {
        [TestMethod]
        public void Test_SignIn()
        {
            var plexApi = ServiceProvider.GetService<IPlexApi>();

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
            var plexApi = ServiceProvider.GetService<IPlexApi>();

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
            var plexApi = ServiceProvider.GetService<IPlexApi>();

            var login = Configuration.GetValue<string>("Plex:Login");
            var password = Configuration.GetValue<string>("Plex:Password");

            PlexAuthentication auth = plexApi
                .SignIn(new UserRequest{ Login = login, Password = password}).Result;
            
            PlexServer account = plexApi.GetServer(auth.User.AuthenticationToken).Result;
            
            Assert.IsNotNull(auth, $"Authentication Failed for {login}/{password}");
            Assert.AreEqual("myPlex", account.FriendlyName);
        }
    }
}