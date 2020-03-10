using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plex.Api.Models;
using Plex.Api.Models.MetaData;

namespace Plex.Api.Tests.Tests
{
    [TestClass]
    public class LibraryTests : TestBase
    {
        [TestMethod]
        public void Test_GetLibrarySections()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            if (string.IsNullOrEmpty(AuthenticationToken))
            {
                SignIn();
            }
            
            Models.Server.PlexServers account = plexApi.GetServers(AuthenticationToken).Result;

            string fullUri = account.Server[0].FullUri.ToString();

            LibrariesWrapper librariesWrapper = plexApi.GetLibrarySections(account.Server[0].AccessToken, fullUri).Result;

            var movieLibrary = librariesWrapper.Libraries.Libraries.First(c => c.Title == "Movies");

            LibraryWrapper library = plexApi.GetLibrary(account.Server[0].AccessToken, fullUri, movieLibrary.Key).Result;
            
            Assert.IsNotNull(librariesWrapper.Libraries, "Error retrieving Libraries");
        } //12063
        
        [TestMethod]
        public void Test_GetLibrary_Metadata_Item()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            const int metadataId = 8576;
            
            if (string.IsNullOrEmpty(AuthenticationToken))
            {
                SignIn();
            }

            Models.Server.PlexServers account = plexApi.GetServers(AuthenticationToken).Result;

            string fullUri = account.Server[0].FullUri.ToString();
        
            MetadataWrapper metadataWrapper = plexApi.GetMetadata(account.Server[0].AccessToken, fullUri, metadataId).Result;
            
        }
    }
}