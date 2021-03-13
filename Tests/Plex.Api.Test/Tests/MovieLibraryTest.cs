namespace Plex.Api.Test.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using ApiModels.Libraries;
    using ApiModels.Libraries.Filters;
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

            var items = await library.SearchMovies(title, "audienceRating:desc", null, start, count);
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
                new()
                {
                    Field = "contentRating", Operator = Operator.Is, Values = new List<string> {"R", "G"}
                }
            };

            var results = await library.SearchMovies(string.Empty, "year:desc", requests, 0, 20);

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
            var filterValues = await library.GetFilterValues("movie","genre", "Action");

            Assert.NotNull(filterValues);
            Assert.True(filterValues.Count == 1);
        }

        [Fact]
        public  void Test_MovieSearchByYear()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "Movies") as MovieLibrary;

            var filters = new List<FilterRequest>
            {
                new()
                {
                    Field = "year", Operator = Operator.Is, Values = new List<string> {"2021"}
                }
            };

            var movieContainer = library.SearchMovies(string.Empty, string.Empty, filters, 0, 20).Result;
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
            var items = await library.AllMovies("year:asc",  0, 10);
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
            var items = await library.SearchMovies(string.Empty,  "year:asc", null, 0, 10);
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

             var collections = await library.Collections();
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
             var items = await library.GetCollectionItemsByName(collectionName);

            Assert.NotNull(items);
         }

         // [Fact]
         // public async System.Threading.Tasks.Task Test_RemoveCollectionFromMovieAsync()
         // {
         //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
         //     var authKey = this.Configuration["Plex:AuthenticationKey"];
         //
         //     var libraryKey = "1";
         //     var movieKey = "8576";
         //     const string collectionName = "Test";
         //
         //     if (plexApi != null)
         //     {
         //         var servers = await plexApi.GetServersAsync(authKey, false);
         //         var fullUri = servers[0].FullUri.ToString();
         //
         //         // Delete Collection to Movie
         //         await plexApi.DeleteCollectionFromMovieAsync(authKey, fullUri, libraryKey, movieKey, collectionName);
         //
         //         // Verify Collection was added
         //         var collections = await plexApi.GetCollectionTagsForMovieAsync(authKey, fullUri, movieKey);
         //
         //         Assert.True(collections == null || !collections.Contains(collectionName));
         //     }
         // }
         //
         // [Fact]
         // public async System.Threading.Tasks.Task Test_GetCollectionChildrenAsync()
         // {
         //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
         //     var authKey = this.Configuration["Plex:AuthenticationKey"];
         //
         //     if (plexApi != null)
         //     {
         //         var servers = await plexApi.GetServersAsync(authKey, false);
         //         var fullUri = servers[0].FullUri.ToString();
         //
         //         var movies = await plexApi.GetChildrenMetadataAsync(authKey, fullUri, 112898);
         //
         //         Assert.True(movies.MediaContainer.Metadata.Count > 0);
         //     }
         // }
         //
         // [Fact]
         // public async System.Threading.Tasks.Task Test_UpdateCollectionAsync()
         // {
         //     var plexApi = this.ServiceProvider.GetService<IPlexClient>();
         //     var authKey = this.Configuration["Plex:AuthenticationKey"];
         //
         //     if (plexApi != null)
         //     {
         //         var servers = await plexApi.GetServersAsync(authKey, false);
         //         var fullUri = servers[0].FullUri.ToString();
         //
         //         const string libraryKey = "1";
         //         const string collectionRatingKey = "96453";
         //         const string tempTitle = "TEST ME";
         //
         //         var collection = await plexApi.GetCollectionAsync(authKey, fullUri, collectionRatingKey);
         //         var originalTitle = collection.Title;
         //         collection.Title = tempTitle;
         //         await plexApi.UpdateCollectionAsync(authKey, fullUri, libraryKey, collection);
         //
         //         var updatedCollection = await plexApi.GetCollectionAsync(authKey, fullUri, collectionRatingKey);
         //         Assert.Equal(updatedCollection.Title, tempTitle);
         //
         //         updatedCollection.Title = originalTitle;
         //         await plexApi.UpdateCollectionAsync(authKey, fullUri, libraryKey, updatedCollection);
         //
         //         var revertedCollection = await plexApi.GetCollectionAsync(authKey, fullUri, collectionRatingKey);
         //         Assert.Equal(originalTitle, revertedCollection.Title);
         //     }
         //}
    }
}

