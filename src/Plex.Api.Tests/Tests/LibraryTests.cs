using System.Collections.Generic;
using System.Linq;
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
        public void Test_GetLibrarySections()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");

            List<Server> servers = plexApi.GetServers(authKey).Result;

            string fullUri = servers[0].FullUri.ToString();

            var plexMediaContainer = plexApi.GetLibraries(servers[0].AccessToken, fullUri).Result;

            var movieLibrary = plexMediaContainer
                .MediaContainer.Directory
                .First(c => c.Title == "Movies");
            
            var movie = plexApi.GetLibrary(servers[0].AccessToken, fullUri, movieLibrary.Key).Result;
            
            var tvLibrary = plexMediaContainer
                .MediaContainer.Directory
                .First(c => c.Title == "TV Shows");
            
            var tv = plexApi.GetLibrary(servers[0].AccessToken, fullUri, tvLibrary.Key).Result;
          
            
            Assert.IsNotNull(movie.MediaContainer.Metadata, "Error retrieving Libraries");
            Assert.IsNotNull(tv.MediaContainer.Metadata, "Error retrieving Libraries");
        }
        
        [TestMethod]
        public void Test_GetLibrary_Metadata_Item()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            const int metadataId = 8576;
            
            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");

            List<Server> servers = plexApi.GetServers(authKey).Result;

            string fullUri = servers[0].FullUri.ToString();
        
            PlexMediaContainer metadataWrapper = plexApi.GetMetadata(servers[0].AccessToken, fullUri, metadataId).Result;
            
            Assert.IsNotNull(metadataWrapper.MediaContainer);
        }
    }
}