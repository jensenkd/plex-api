using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public void Test_Get_MetadataForLibrary()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");
            List<Server> servers = plexApi.GetServers(authKey).Result;

            string fullUri = servers[0].FullUri.ToString();

            var items = plexApi.GetMetadataForLibrary(authKey, fullUri, "1").Result;

            Assert.IsTrue(items.MediaContainer.Metadata.Any());
        }

        [TestMethod]
        public void Test_UnscrobbleItem()
        {
            const string ratingKey = "92712";
            
            var plexApi = ServiceProvider.GetService<IPlexClient>();
            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");
            List<Server> servers = plexApi.GetServers(authKey).Result;
            string fullUri = servers[0].FullUri.ToString();
            plexApi.UnScrobbleItem(authKey, fullUri, ratingKey);
            PlexMediaContainer after = plexApi.GetMetadata(authKey, fullUri, int.Parse(ratingKey)).Result;

            Assert.AreEqual(after.MediaContainer.Metadata[0].ViewCount, 0);
        }
        
        [TestMethod]
        public void Test_ScrobbleItem()
        {
            const string ratingKey = "92712";
            
            var plexApi = ServiceProvider.GetService<IPlexClient>();
            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");
            List<Server> servers = plexApi.GetServers(authKey).Result;
            string fullUri = servers[0].FullUri.ToString();
            PlexMediaContainer before = plexApi.GetMetadata(authKey, fullUri, int.Parse(ratingKey)).Result;
            plexApi.ScrobbleItem(authKey, fullUri, ratingKey);
            PlexMediaContainer after = plexApi.GetMetadata(authKey, fullUri, int.Parse(ratingKey)).Result;

            Assert.AreEqual(after.MediaContainer.Metadata[0].ViewCount, before.MediaContainer.Metadata[0].ViewCount + 1);
            
        }

        [TestMethod]
        public void Test_Get_All_Movies()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");
            List<Server> servers = plexApi.GetServers(authKey).Result;

            string fullUri = servers[0].FullUri.ToString();
            
            var movieLibraries = new[] {"Movies"};

            var libraries = plexApi.GetLibraries(authKey, fullUri).Result;

            List<Directory> directories = libraries.MediaContainer.Directory.
                Where(c => movieLibraries.Contains(c.Title, StringComparer.OrdinalIgnoreCase)).ToList();

            List<Metadata> movies = new List<Metadata>();
            foreach (var directory in directories)
            {
                var items = plexApi.GetLibrary(authKey, fullUri, directory.Key).Result.MediaContainer.Metadata;
                movies.AddRange(items);
            }
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