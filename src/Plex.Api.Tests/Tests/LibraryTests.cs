using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plex.Api.Models;

namespace Plex.Api.Tests.Tests
{
    [TestClass]
    public class LibraryTests : TestBase
    {
        [TestMethod]
        public void Test_GetLibrarySections()
        {
            var plexApi = ServiceProvider.GetService<IPlexApi>();

            var login = Configuration.GetValue<string>("Plex:Login");
            var password = Configuration.GetValue<string>("Plex:Password");

            PlexAuthentication auth = plexApi
                .SignIn(new UserRequest{ Login = login, Password = password}).Result;
            
            Models.Server.PlexServers account = plexApi.GetServers(auth.User.AuthenticationToken).Result;

            string fullUri = account.Server[0].FullUri.ToString();

            LibrariesWrapper librariesWrapper = plexApi.GetLibrarySections(account.Server[0].AccessToken, fullUri).Result;

            var movieLibrary = librariesWrapper.Libraries.Libraries.First(c => c.Title == "Movies");

            LibraryWrapper library = plexApi.GetLibrary(account.Server[0].AccessToken, fullUri, movieLibrary.Key).Result;
            
            Assert.IsNotNull(auth, $"Authentication Failed for {login}/{password}");
            Assert.IsNotNull(librariesWrapper.Libraries, "Error retrieving Libraries");
        }
    }
}