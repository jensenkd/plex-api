using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plex.Api.Models;
using Plex.Api.Models.Server;

namespace Plex.Api.Tests.Tests
{
    [TestClass]
    public class LibraryTests : TestBase
    {
        [TestMethod]
        public void Test_GetLibraries()
        {
            var plexApi = ServiceProvider.GetService<IPlexApi>();

            var login = Configuration.GetValue<string>("Plex:Login");
            var password = Configuration.GetValue<string>("Plex:Password");

            PlexAuthentication auth = plexApi
                .SignIn(new UserRequest{ Login = login, Password = password}).Result;
            
            PlexServer account = plexApi.GetServer(auth.User.AuthenticationToken).Result;

            string fullUri = account.Server[0].FullUri.ToString();

            PlexContainer sections = plexApi.GetLibrarySections(account.Server[0].AccessToken, fullUri).Result;

            PlexContainer library = plexApi.GetLibrary(account.Server[0].AccessToken, fullUri, sections.MediaContainer.Directory[0].Key).Result;

            Assert.IsNotNull(auth, $"Authentication Failed for {login}/{password}");
            Assert.IsNotNull(sections.MediaContainer, "Error retrieving Libraries");
        }
    }
}