namespace Plex.Api.Test.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using ApiModels;
    using ApiModels.Libraries;
    using Enums;
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
        public async void Test_Get_Library_By_Name()
        {
            var libraries = await this.fixture.Server.Libraries();
            Assert.NotNull(libraries);
            Assert.True(libraries.Count >= 3);

            var library = (ShowLibrary)libraries.SingleOrDefault(c => c.Title == "TV Shows");
            Assert.NotNull(library);
            Assert.Equal("TV Shows", library.Title);
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
            var library = (MovieLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
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
            var filters = library.Filters;

            Assert.NotNull(filters);
        }

        [Fact]
        public async void Test_LibrarySearchByName()
        {
            var library = (MovieLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");

            const string title = "Harry Potter";
            const int start = 0;
            const int count = 2;
            var filters = new Dictionary<string, string>();

            var items = await library.Search(true, title, "audienceRating:desc", SearchType.Movie, filters, start, count);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }
            Assert.NotNull(items);
            Assert.Equal(count, items.Media.Count);
        }

        [Fact]
        public async void Test_LibraryFilterValues()
        {
            var library = (MovieLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");

            var filterValues = library.GetFilterValues("genre").Result;

            Assert.NotNull(filterValues);
            Assert.True(filterValues.Size > 0);
        }

        [Fact]
        public async void Test_LibrarySearchByPerson()
        {
            var library = (MovieLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");

            var filter = new Dictionary<string, string>
                {{"actor", "Tom Cruise"}};

            var movieContainer = library.Search(true, string.Empty, string.Empty, SearchType.Movie, filter).Result;

            Assert.NotNull(movieContainer);
        }

        [Fact]
        public async void Test_LibrarySearchMusicByArtist()
        {
            var library = (MusicLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Music");

            const string title = "Guns";
            const int start = 0;
            const int count = 24;
            var filters = new Dictionary<string, string>();

            var items = await library.SearchArtists(title, "audienceRating:desc", filters, start, count);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_LibrarySearchMusicByTrack()
        {
            var library = (MusicLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Music");

            const string title = "November";
            const int start = 0;
            const int count = 24;
            var filters = new Dictionary<string, string>();

            var items = await library.SearchTracks(title, "audienceRating:desc", filters, start, count);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_LibrarySearchMusicByAlbum()
        {
            var library = (MusicLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Music");

            var searchFilters = await library.FilterFields();

            const string title = "Black";
            const int start = 0;
            const int count = 24;
            var filters = new Dictionary<string, string>();

            var items = await library.SearchAlbums(title, "audienceRating:desc", filters, start, count);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_LibrarySearchTVByName()
        {
            var library = (ShowLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "TV Shows");

            const string title = "hard";
            const int start = 0;
            const int count = 20;
            var filters = new Dictionary<string, string>();

            var items = await library.SearchEpisodes(true, title, "audienceRating:desc", filters, start, count);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }
            Assert.NotNull(items);
            Assert.Equal(count, items.Media.Count);
        }

        [Fact]
        public async void Test_LibraryAll()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            var items = await library.All(true, SearchType.Movie, "year:asc",  0, 10);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_LibraryOperators()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            var items = await library.Search(true, string.Empty,  "year:asc", SearchType.Movie, null, 0, 10);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_Library_GetSize()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            int size = await library.Size();
            Assert.True(size > 3000);
        }

        [Fact]
        public async void Test_Library_Folders()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            var folders = await library.Folders();
            Assert.NotNull(folders);
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
