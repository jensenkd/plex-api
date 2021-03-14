namespace Plex.Api.Test.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Library.ApiModels.Libraries;
    using PlexModels.Library;
    using PlexModels.Library.Search;
    using Xunit;
    using Xunit.Abstractions;

    public class MusicLibraryTest : IClassFixture<PlexFixture>
    {
        private readonly PlexFixture fixture;
        private readonly ITestOutputHelper output;

        public MusicLibraryTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.fixture = fixture;
        }

        [Fact]
        public async void Test_SearchAlbumByTitle()
        {
            var library = (MusicLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Music");

            const string title = "And Justice For All";
            const int start = 0;
            const int count = 2;

            var items = await library.SearchAlbums(title, string.Empty, null, start, count);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Artist: " + item.ParentTitle);
                this.output.WriteLine("Year: " + item.Year);
            }
            Assert.NotNull(items);
            Assert.Equal(count, items.Media.Count);
        }

        [Fact]
        public async void Test_ArtistGenreSearch()
        {
            var library = (MusicLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Music");

            var filters = new List<FilterRequest>
            {
                new()
                {
                    Field = "genre", Operator = Operator.Is, Values = new List<string> {"Country", "Rap"}
                }
            };

            const string artist = "Linkin";

            var results = await library.SearchArtists(artist, "year:desc", filters, 0, 20);

            foreach (var item in results.Media)
            {
                this.output.WriteLine($"{item.Title} ({item.Year}) - {item.ContentRating}");
                foreach (var genre in item.Genres)
                {
                    this.output.WriteLine(genre.Tag);
                }
            }

            Assert.NotNull(results);
        }

        [Fact]
        public async void Test_ArtistNameSearch()
        {
            var library = (MusicLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Music");

            const string title = "Guns";
            const int start = 0;
            const int count = 24;
            var filters = new List<FilterRequest>();

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
            var filters = new List<FilterRequest>();

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

            const string title = "Black";
            const int start = 0;
            const int count = 24;

            var items = await library.SearchAlbums(title, "year:desc", null, start, count);
            foreach (var item in items.Media)
            {
                this.output.WriteLine("Title: " + item.Title);
                this.output.WriteLine("Year: " + item.Year);
                this.output.WriteLine("Rating: " + item.AudienceRating);
            }
            Assert.NotNull(items);
        }

        [Fact]
        public async void Test_GetAllArtists()
        {
            var library = (MusicLibrary)this.fixture.Server.Libraries().Result.Single(c => c.Title == "Music");
            var items = await library.AllArtists( "year:asc",  0, 10);
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

