namespace Plex.Api.Test.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using PlexModels.Library;
    using Xunit;
    using Xunit.Abstractions;

    public class LibraryTest : IClassFixture<PlexFixture>
    {
        private readonly PlexFixture fixture;
        private readonly ITestOutputHelper output;

        public LibraryTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.fixture = fixture;
        }

        [Fact]
        public async void Test_GetLibraryHub()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            const int count = 5; // Max Count of items on each hub
            var items = await library.Hubs(count);
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_GetLibraryRecentlyAddedItems()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            const int start = 0;
            const int count = 5;
            var items = await library.RecentlyAdded(start, count);
            Assert.Equal(items.Size, count);
        }

        [Fact]
        public async void Test_EmptyTrashForLibrary()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            await library.EmptyTrash();
        }

        [Fact]
        public async void Test_GetPlexServerLibraryByKey()
        {
            const string key = "1";
            var filter = new LibraryFilter() {Keys = new List<string> {key}};
            var libraries = await this.fixture.Server.Libraries(filter);
            Assert.NotNull(libraries);
            Assert.Single(libraries);
            Assert.Equal(key, libraries[0].Key);
        }

        [Fact]
        public async void Test_GetPlexServerLibrariesByType()
        {
            const string type = "movie";
            var filter = new LibraryFilter() {Types = new List<string> {type}};
            var libraries = await this.fixture.Server.Libraries(filter);
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
            var libraries = await this.fixture.Server.Libraries(filter);
            Assert.NotNull(libraries);
            foreach (var library in libraries)
            {
                Assert.Equal(title, libraries[0].Title);
            }
        }

        [Fact]
        public async void Test_LibraryScan()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            await library.ScanForNewItems(false);
        }

        [Fact]
        public async void Test_CancelLibraryScan()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            await library.CancelScan();
        }

        [Fact]
        public async void Test_GetLibrarySearchFilters()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            var filters = await library.SearchFilters();
            Assert.NotNull(filters);
        }

        [Fact]
        public async void Test_LibrarySearchByName()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");

            const string title = "Harry Potter";
            var filters = new Dictionary<string, string>();

            var items = await library.Search(title, "audienceRating:desc", string.Empty, filters);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }
            Assert.NotNull(items);
            Assert.Equal(8, items.Media.Count);
        }

        [Fact]
        public async void Test_LibraryAll()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            var items = await library.All("audienceRating:desc", 0, 10);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }
            Assert.NotNull(items);
        }
    }
}

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
