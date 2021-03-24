namespace Plex.ServerApi.Test.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Library.ApiModels.Libraries;
    using PlexModels.Library;
    using PlexModels.Library.Search;
    using Xunit;
    using Xunit.Abstractions;

    public class MovieLibraryTest : IClassFixture<PlexFixture>
    {
        private readonly PlexFixture fixture;
        private readonly ITestOutputHelper output;

        public MovieLibraryTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.fixture = fixture;
        }

        [Fact]
        public async void Test_GetRecentlyAddedMovies()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
            const int start = 0;
            const int count = 5;
            var items = await library.RecentlyAdded(start, count);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }

            Assert.Equal(items.Size, count);
        }

        [Fact]
        public async void Test_SearchMovieByName()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;

            const string title = "Harry Potter";
            const int start = 0;
            const int count = 8;

            var items = await library.SearchMovies( title, "audienceRating:desc", null, false, start, count);
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
        public async void Test_MovieContentRatingSearch()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;

            var requests = new List<FilterRequest>
            {
                new() {Field = "contentRating", Operator = Operator.Is, Values = new List<string> {"R", "G"}}
            };

            var results = await library.SearchMovies(string.Empty, "year:desc", requests, false, 0, 20);

            foreach (var item in results.Media)
            {
                this.output.WriteLine($"{item.Title} ({item.Year}) - {item.ContentRating}");
                Assert.Contains(item.ContentRating, requests[0].Values);
            }
        }

        [Fact]
        public async void Test_MovieFilterValues()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
            var filterValues = await library.GetFilterValues("movie", "genre", "Action");

            Assert.NotNull(filterValues);
            Assert.True(filterValues.Count == 1);
        }

        [Fact]
        public void Test_MovieSearchByYear()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;

            var filters = new List<FilterRequest>
            {
                new() {Field = "year", Operator = Operator.Is, Values = new List<string> {"2021"}}
            };

            var movieContainer = library.SearchMovies(string.Empty, string.Empty, filters, false, 0, 20).Result;
            foreach (var movie in movieContainer.Media)
            {
                Assert.Contains(movie.Year.ToString(), filters[0].Values);
            }

            Assert.NotNull(movieContainer);
        }

        [Fact]
        public async void Test_AllMovies()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
            var items = await library.AllMovies(false, "year:asc", 0, 10);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }

            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_SearchMovieWithSort()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
            var items = await library.SearchMovies(string.Empty, "year:asc", null, false, 0, 10);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }

            Assert.NotNull(items);
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_GetCollectionsAsync()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
            Assert.NotNull(library);

            const string collectionName = "Test";
            var collections = await library.Collections(collectionName);
            foreach (var item in collections)
            {
                this.output.WriteLine("Title: " + item.Title);
            }

            Assert.NotNull(collections);
            Assert.True(collections.Count > 0);
        }

        [Fact]
        public async void Test_GetCollectionAsync()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
            Assert.NotNull(library);

            const string collectionKey = "112898";

            var collection = await library.Collection(collectionKey);
            Assert.NotNull(collection);
            this.output.WriteLine("Title: " + collection.Title);
            Assert.Equal("Poster", collection.Title);
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_AddCollectionToMovieAsync()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
            Assert.NotNull(library);

            var movieKey = "8576";
            const string collectionName = "Test";

            // Add Collection to Movie
            await library.AddCollectionToItem(movieKey, collectionName);

            // Verify Collection was added
            var items = await library.CollectionItemsByName(collectionName);

            Assert.Contains(movieKey, items.Media.Select(c => c.RatingKey));
        }

        [Fact]
        public async Task Test_RemoveCollectionFromMovieAsync()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
            Assert.NotNull(library);

            var movieKey = "8576";
            const string collectionName = "Test";

            // Delete Collection to Movie
            await library.RemoveCollectionFromItem(movieKey, collectionName);

            // Verify Collection was removed
            var items = await library.CollectionItemsByName(collectionName);

            Assert.DoesNotContain(movieKey, items.Media.Select(c => c.RatingKey));
        }


        [Fact]
        public async Task Test_GetCollectionChildrenByKey()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
            Assert.NotNull(library);

            const string collectionKey = "113834";
            var items = await library.CollectionItemsMetadataByKey(collectionKey);

            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }

            Assert.NotNull(items);
        }

        [Fact]
        public async Task Test_GetCollectionChildrenByName()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
            Assert.NotNull(library);

            const string collectionName = "Test";
            var items = await library.CollectionItemsMetadataByName(collectionName);

            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }

            Assert.NotNull(items);
        }

         [Fact]
         public async void Test_UpdateCollectionAsync()
         {
             var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;
             Assert.NotNull(library);

             const string collectionRatingKey = "113834";
             var tempTitle = "Test-" + DateTime.Now.ToShortDateString();

             var collection = await library.Collection(collectionRatingKey);
             var originalTitle = collection.Title;
             this.output.WriteLine("Original Title: " + originalTitle);
             collection.Title = tempTitle;
             this.output.WriteLine("Updated Title:" + collection.Title);
             library.UpdateCollection(collection);

             var updatedCollection = await library.Collection(collectionRatingKey);
             Assert.Equal(updatedCollection.Title, tempTitle);
             this.output.WriteLine("Updated Title:" + updatedCollection.Title);
             updatedCollection.Title = originalTitle;
             library.UpdateCollection(updatedCollection);

             var revertedCollection = await library.Collection(collectionRatingKey);
             this.output.WriteLine("Original Title: " + revertedCollection.Title);
             Assert.Equal(originalTitle, revertedCollection.Title);
         }
    }
}
