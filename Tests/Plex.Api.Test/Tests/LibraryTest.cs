namespace Plex.Api.Test.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using PlexModels.Media;
    using Xunit;

    public class LibraryTest : TestBase
    {
        [Fact]
        public async void Test_GetLibraryHub()
        {
            const string libraryKey = "1";
            const int count = 5; // Max  Count of items on each hub
            var items = await this.Server.GetLibraryHub(libraryKey, count);
            Assert.NotNull(items);
        }

       [Fact]
        public async void Test_GetLibraryRecentlyAddedItems()
        {
            const string libraryKey = "1";
            const int start = 0;
            const int count = 5;
            var items = await this.Server.GetLibraryRecentlyAdded(libraryKey, start, count);
            Assert.Equal(items.Size, count);
        }

        // [Fact]
        // public async void Test_SearchLibraryByName()
        // {
        //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
        //     var authKey = this.Configuration["Plex:AuthenticationKey"];
        //
        //     if (plexApi != null)
        //     {
        //         var servers = await plexApi.GetServersAsync(authKey, false);
        //         var fullUri = servers[0].FullUri.ToString();
        //
        //         var movies = await plexApi.SearchAsync(authKey, fullUri, "Harry Potter");
        //
        //         Assert.NotNull(movies);
        //     }
        // }
        //
        // [Fact]
        // public async System.Threading.Tasks.Task Test_GetLibrarySectionsAsync()
        // {
        //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
        //     var authKey = this.Configuration["Plex:AuthenticationKey"];
        //
        //     if (plexApi != null)
        //     {
        //         var servers = await plexApi.GetServersAsync(authKey,false);
        //
        //         var fullUri = servers[0].FullUri.ToString();
        //
        //         var plexMediaContainer = await plexApi.GetLibrariesAsync(servers[0].AccessToken, fullUri);
        //
        //         var movieLibrary = plexMediaContainer
        //             .MediaContainer.Directory
        //             .First(c => c.Title == "Movies");
        //
        //         var movie = await
        //             plexApi.GetLibraryAsync(servers[0].AccessToken, fullUri, movieLibrary.Key);
        //
        //         var tvLibrary = plexMediaContainer
        //             .MediaContainer.Directory
        //             .First(c => c.Title == "TV Shows");
        //
        //         var tv = await
        //             plexApi.GetLibraryAsync(servers[0].AccessToken, fullUri, tvLibrary.Key);
        //
        //         Assert.NotNull(movie.MediaContainer.Metadata);
        //         Assert.NotNull(tv.MediaContainer.Metadata);
        //     }
        // }
        //
        // [Fact]
        // public async System.Threading.Tasks.Task Test_Get_MetadataForLibraryAsync()
        // {
        //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
        //
        //     var authKey = this.Configuration["Plex:AuthenticationKey"];
        //     if (plexApi != null)
        //     {
        //         var servers = await plexApi.GetServersAsync(authKey, false);
        //
        //         var fullUri = servers[0].FullUri.ToString();
        //
        //         var items = await plexApi.GetMetadataForLibraryAsync(authKey, fullUri, "1");
        //
        //         Assert.True(items.MediaContainer.Metadata.Any());
        //     }
        // }
        //
        // [Fact]
        // public async System.Threading.Tasks.Task Test_UnscrobbleItemAsync()
        // {
        //     const string ratingKey = "92712";
        //
        //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
        //     var authKey = this.Configuration["Plex:AuthenticationKey"];
        //     if (plexApi != null)
        //     {
        //         var servers = await plexApi.GetServersAsync(authKey, false);
        //         var fullUri = servers[0].FullUri.ToString();
        //         await plexApi.UnScrobbleItemAsync(authKey, fullUri, ratingKey);
        //         var after = await plexApi.GetMetadataAsync(authKey, fullUri, int.Parse(ratingKey));
        //
        //         Assert.Equal(0, after.MediaContainer.Metadata[0].ViewCount);
        //     }
        // }
        //
        // [Fact]
        // public async System.Threading.Tasks.Task Test_ScrobbleItemAsync()
        // {
        //     const string ratingKey = "92712";
        //
        //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
        //     var authKey = this.Configuration["Plex:AuthenticationKey"];
        //     if (plexApi != null)
        //     {
        //         var servers = await plexApi.GetServersAsync(authKey, false);
        //         var fullUri = servers[0].FullUri.ToString();
        //         var before = await plexApi.GetMetadataAsync(authKey, fullUri, int.Parse(ratingKey));
        //
        //         await plexApi.ScrobbleItemAsync(authKey, fullUri, ratingKey);
        //
        //         var after = await plexApi.GetMetadataAsync(authKey, fullUri, int.Parse(ratingKey));
        //
        //         Assert.Equal(after.MediaContainer.Metadata[0].ViewCount, before.MediaContainer.Metadata[0].ViewCount + 1);
        //     }
        // }
        //
        // [Fact]
        // public async System.Threading.Tasks.Task Test_Get_All_MoviesAsync()
        // {
        //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
        //
        //     var authKey = this.Configuration["Plex:AuthenticationKey"];
        //     if (plexApi != null)
        //     {
        //         var servers = await plexApi.GetServersAsync(authKey, false);
        //
        //         var fullUri = servers[0].FullUri.ToString();
        //
        //         var movieLibraries = new[] { "Movies" };
        //
        //         var libraries = await plexApi.GetLibrariesAsync(authKey, fullUri);
        //
        //         var directories = libraries.MediaContainer.Directory.
        //             Where(c => movieLibraries.Contains(c.Title, StringComparer.OrdinalIgnoreCase)).ToList();
        //
        //         var movies = new List<Metadata>();
        //         foreach (var directory in directories)
        //         {
        //             var items = (await plexApi.GetLibraryAsync(authKey, fullUri, directory.Key)).MediaContainer.Metadata;
        //             movies.AddRange(items);
        //         }
        //     }
        // }
        //
        // [Fact]
        // public async System.Threading.Tasks.Task Test_GetLibrary_Metadata_ItemAsync()
        // {
        //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
        //
        //     const int metadataId = 8576;
        //
        //     var authKey = this.Configuration["Plex:AuthenticationKey"];
        //
        //     if (plexApi != null)
        //     {
        //         var servers = await plexApi.GetServersAsync(authKey, false);
        //
        //         var fullUri = servers[0].FullUri.ToString();
        //
        //         var metadataWrapper = await plexApi.GetMetadataAsync(servers[0].AccessToken, fullUri, metadataId);
        //
        //         Assert.NotNull(metadataWrapper.MediaContainer);
        //     }
        // }
    }
}
