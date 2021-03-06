// namespace Plex.Api.Test
// {
//     using Microsoft.Extensions.DependencyInjection;
//     using Xunit;
//
//     public class CollectionTest : TestBase
//     {
//         [Fact]
//         public async System.Threading.Tasks.Task Test_GetCollectionsAsync()
//         {
//             var plexApi = this.ServiceProvider.GetService<IPlexClient>();
//             var authKey = this.Configuration["Plex:AuthenticationKey"];
//
//             if (plexApi != null)
//             {
//                 var servers = await plexApi.GetServersAsync(authKey, false);
//                 var fullUri = servers[0].FullUri.ToString();
//
//                 var collections = await plexApi.GetCollectionsAsync(authKey, fullUri, "1");
//
//                 Assert.NotNull(collections);
//                 Assert.True(collections.Count > 0);
//             }
//         }
//
//         [Fact]
//         public async System.Threading.Tasks.Task Test_GetCollectionAsync()
//         {
//             var plexApi = this.ServiceProvider.GetService<IPlexClient>();
//             var authKey = this.Configuration["Plex:AuthenticationKey"];
//
//             if (plexApi != null)
//             {
//                 var servers = await plexApi.GetServersAsync(authKey, false);
//                 var fullUri = servers[0].FullUri.ToString();
//
//                 var collection = await plexApi.GetCollectionAsync(authKey, fullUri, "112898");
//
//                 Assert.Equal("Poster", collection.Title);
//             }
//         }
//
//         [Fact]
//         public async System.Threading.Tasks.Task Test_AddCollectionToMovieAsync()
//         {
//             var plexApi = this.ServiceProvider.GetService<IPlexClient>();
//             var authKey = this.Configuration["Plex:AuthenticationKey"];
//
//             var libraryKey = "1";
//             var movieKey = "8576";
//             const string collectionName = "Test";
//
//             if (plexApi != null)
//             {
//                 var servers = await plexApi.GetServersAsync(authKey, false);
//                 var fullUri = servers[0].FullUri.ToString();
//
//                 // Add Collection to Movie
//                 await plexApi.AddCollectionToMovieAsync(authKey, fullUri, libraryKey ,movieKey, collectionName);
//
//                 // Verify Collection was added
//                 var collections = await plexApi.GetCollectionTagsForMovieAsync(authKey, fullUri, movieKey);
//
//                 Assert.NotNull(collections);
//                 Assert.Contains(collectionName, collections);
//             }
//         }
//
//         [Fact]
//         public async System.Threading.Tasks.Task Test_RemoveCollectionFromMovieAsync()
//         {
//             var plexApi = this.ServiceProvider.GetService<IPlexClient>();
//             var authKey = this.Configuration["Plex:AuthenticationKey"];
//
//             var libraryKey = "1";
//             var movieKey = "8576";
//             const string collectionName = "Test";
//
//             if (plexApi != null)
//             {
//                 var servers = await plexApi.GetServersAsync(authKey, false);
//                 var fullUri = servers[0].FullUri.ToString();
//
//                 // Delete Collection to Movie
//                 await plexApi.DeleteCollectionFromMovieAsync(authKey, fullUri, libraryKey, movieKey, collectionName);
//
//                 // Verify Collection was added
//                 var collections = await plexApi.GetCollectionTagsForMovieAsync(authKey, fullUri, movieKey);
//
//                 Assert.True(collections == null || !collections.Contains(collectionName));
//             }
//         }
//
//         [Fact]
//         public async System.Threading.Tasks.Task Test_GetCollectionChildrenAsync()
//         {
//             var plexApi = this.ServiceProvider.GetService<IPlexClient>();
//             var authKey = this.Configuration["Plex:AuthenticationKey"];
//
//             if (plexApi != null)
//             {
//                 var servers = await plexApi.GetServersAsync(authKey, false);
//                 var fullUri = servers[0].FullUri.ToString();
//
//                 var movies = await plexApi.GetChildrenMetadataAsync(authKey, fullUri, 112898);
//
//                 Assert.True(movies.MediaContainer.Metadata.Count > 0);
//             }
//         }
//
//         [Fact]
//         public async System.Threading.Tasks.Task Test_UpdateCollectionAsync()
//         {
//             var plexApi = this.ServiceProvider.GetService<IPlexClient>();
//             var authKey = this.Configuration["Plex:AuthenticationKey"];
//
//             if (plexApi != null)
//             {
//                 var servers = await plexApi.GetServersAsync(authKey, false);
//                 var fullUri = servers[0].FullUri.ToString();
//
//                 const string libraryKey = "1";
//                 const string collectionRatingKey = "96453";
//                 const string tempTitle = "TEST ME";
//
//                 var collection = await plexApi.GetCollectionAsync(authKey, fullUri, collectionRatingKey);
//                 var originalTitle = collection.Title;
//                 collection.Title = tempTitle;
//                 await plexApi.UpdateCollectionAsync(authKey, fullUri, libraryKey, collection);
//
//                 var updatedCollection = await plexApi.GetCollectionAsync(authKey, fullUri, collectionRatingKey);
//                 Assert.Equal(updatedCollection.Title, tempTitle);
//
//                 updatedCollection.Title = originalTitle;
//                 await plexApi.UpdateCollectionAsync(authKey, fullUri, libraryKey, updatedCollection);
//
//                 var revertedCollection = await plexApi.GetCollectionAsync(authKey, fullUri, collectionRatingKey);
//                 Assert.Equal(originalTitle, revertedCollection.Title);
//             }
//         }
//     }
// }
