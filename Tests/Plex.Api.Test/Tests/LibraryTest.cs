namespace Plex.Api.Test.Tests
{
    using System.Collections.Generic;
    using PlexModels.Library;
    using Xunit;

    public class LibraryTest : TestBase
    {
        [Fact]
        public async void Test_GetLibraryHub()
        {
            const string libraryKey = "1";
            const int count = 5; // Max Count of items on each hub
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

        [Fact]
        public async void Test_EmptyTrashForLibrary()
        {
            const string libraryKey = "1";
            const int start = 0;
            const int count = 5;
            await this.Server.EmptyTrashForLibrary(libraryKey);
        }

        [Fact]
        public async void Test_GetPlexServerLibrarySummary()
        {
            var librarySummary = await this.Server.GetLibrarySummary();
            Assert.NotNull(librarySummary);
        }

        [Fact]
        public async void Test_GetPlexServerLibraryByKey()
        {
            const string key = "1";
            var filter = new LibraryFilter() {Keys = new List<string> {key}};
            var libraries = await this.Server.GetLibraries(filter);
            Assert.NotNull(libraries);
            Assert.Single(libraries);
            Assert.Equal(key, libraries[0].Key);
        }

        [Fact]
        public async void Test_GetPlexServerLibrariesByType()
        {
            const string type = "movie";
            var filter = new LibraryFilter() {Types = new List<string> {type}};
            var libraries = await this.Server.GetLibraries(filter);
            Assert.NotNull(libraries);
            foreach (var library in libraries)
            {
                Assert.Equal(type, libraries[0].Type);
            }
        }

        [Fact]
        public async void Test_GetPlexServerLibrariesByTitle()
        {
            const string title = "Movies";
            var filter = new LibraryFilter() {Titles = new List<string> {title}};
            var libraries = await this.Server.GetLibraries(filter);
            Assert.NotNull(libraries);
            foreach (var library in libraries)
            {
                Assert.Equal(title, libraries[0].Title);
            }
        }

        [Fact]
        public async void Test_LibraryScan()
        {
            const string libraryKey = "1";
            await this.Server.ScanLibraryForNewItems(libraryKey);
        }

        [Fact]
        public async void Test_CancelLibraryScan()
        {
            const string libraryKey = "2";
            await this.Server.CancelLibraryScan(libraryKey);
        }

        [Fact]
        public async void Test_HubSearchByName()
        {
            const string title = "Harry Potter";
            var items = await this.Server.HubLibrarySearch(title);
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_GetLibrarySearchFilters()
        {
            const string libraryKey = "1";
            var filters = await this.Server.GetSearchFiltersForLibrary(libraryKey);
            Assert.NotNull(filters);
        }

        [Fact]
        public async void Test_LibrarySearchByName()
        {
            const string title = "Harry Potter";
            var filters = new Dictionary<string, string> {{"year", "2002"}};
            var items = await this.Server.LibrarySearch(title, "1", string.Empty,  string.Empty, filters);
            Assert.NotNull(items);
            Assert.Single(items.Media);
        }

    }

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

