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
    public class CollectionTests : TestBase
    {
        [TestMethod]
        public void Test_GetCollections()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");
          
            List<Server> servers = plexApi.GetServers(authKey).Result;
            string fullUri = servers[0].FullUri.ToString();

            var collections = plexApi.GetCollections(authKey, fullUri, "1").Result;

            Assert.IsNotNull(collections);
            Assert.IsTrue(collections.Count > 0);
        }
        
        [TestMethod]
        public void Test_AddCollectionToMovie()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");

            var libraryKey = "1";
            var movieKey = "8576";
            const string collectionName = "Test";
            
            List<Server> servers = plexApi.GetServers(authKey).Result;
            string fullUri = servers[0].FullUri.ToString();

            // Add Collection to Movie
            plexApi.AddCollectionToMovie(authKey, fullUri, libraryKey ,movieKey, collectionName);

            // Verify Collection was added
            List<string> collections = plexApi.GetCollectionTagsForMovie(authKey, fullUri, movieKey).Result;
            
            Assert.IsNotNull(collections);
            Assert.IsTrue(collections.Contains(collectionName));
        }
        
        [TestMethod]
        public void Test_RemoveCollectionFromMovie()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");

            var libraryKey = "1";
            var movieKey = "8576";
            const string collectionName = "Test";
            
            List<Server> servers = plexApi.GetServers(authKey).Result;
            string fullUri = servers[0].FullUri.ToString();

            // Add Collection to Movie
            plexApi.DeleteCollectionFromMovie(authKey, fullUri, libraryKey ,movieKey, collectionName);

            // Verify Collection was added
            List<string> collections = plexApi.GetCollectionTagsForMovie(authKey, fullUri, movieKey).Result;
            
            Assert.IsTrue(collections == null || !collections.Contains(collectionName));
        }
        
        [TestMethod]
        public void Test_UpdateCollection()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var authKey = Configuration.GetValue<string>("Plex:AuthenticationKey");
          
            List<Server> servers = plexApi.GetServers(authKey).Result;
            string fullUri = servers[0].FullUri.ToString();

            const string libraryKey = "1";
            const string collectionRatingKey = "96453";
            const string tempTitle = "TEST ME";
            
            var collection = plexApi.GetCollection(authKey, fullUri, collectionRatingKey).Result;
            var originalTitle = collection.Title;
            collection.Title = tempTitle;
            plexApi.UpdateCollection(authKey, fullUri, libraryKey, collection);
            
            var updatedCollection = plexApi.GetCollection(authKey, fullUri, collectionRatingKey).Result;
            Assert.AreEqual(updatedCollection.Title, tempTitle);

            updatedCollection.Title = originalTitle;
            plexApi.UpdateCollection(authKey, fullUri, libraryKey, updatedCollection);
            
            var revertedCollection = plexApi.GetCollection(authKey, fullUri, collectionRatingKey).Result;
            Assert.AreEqual(originalTitle, revertedCollection.Title);
        }
    }
}