namespace Plex.Api.Test.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Library.ApiModels.Libraries;
    using PlexModels.Library;
    using Xunit;
    using Xunit.Abstractions;

    public class LibraryBaseTest : IClassFixture<PlexFixture>
    {
        private readonly PlexFixture fixture;
        private readonly ITestOutputHelper output;

        public LibraryBaseTest(ITestOutputHelper output, PlexFixture fixture)
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
            var libTypes = new List<string> {"movie", "audio"};
            var filter = new LibraryFilter() {Types = libTypes};
            var libraries = await this.fixture.Server.Libraries(filter);
            Assert.NotNull(libraries);
            foreach (var library in libraries)
            {
                Assert.Contains(library.Type, libTypes);
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
            var filters = library.FilterFields;

            Assert.NotNull(filters);
        }

        [Fact]
        public async void Test_LibraryFilters()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            var filterValues = library.FilterFields;

            Assert.NotNull(filterValues);
        }

        [Fact]
        public async void Test_LibraryFilterValues()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            var filterValues = await library.GetFilterValues("movie", "genre", string.Empty);

            Assert.True(filterValues.Count > 0);
        }

        [Fact]
        public async void Test_Library_GetSize()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies");
            var size = await library.Size();
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
