namespace Plex.ServerApi.Test.Tests;

using System.Linq;
using Library.ApiModels.Libraries;
using Xunit;
using Xunit.Abstractions;

public class TvLibraryTest : IClassFixture<PlexFixture>
    {
        private readonly PlexFixture fixture;
        private readonly ITestOutputHelper output;

        public TvLibraryTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.fixture = fixture;
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_GetShows()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "TV Shows") as ShowLibrary;
            Assert.NotNull(library);


            var shows = await library.AllShows("");
            Assert.NotNull(shows);
            Assert.True(shows.Media.Count > 0);

            var show = shows.Media.First();
            Assert.NotNull(show);

            Assert.True(show.ChildCount > 0);
            Assert.True(show.LeafCount > 0);
            if (show.ViewCount > 0)
            {
                Assert.True(show.ViewedLeafCount > 0);
            }
        }


        [Fact]
        public async System.Threading.Tasks.Task Test_GetSeasonsForShow()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "TV Shows") as ShowLibrary;
            Assert.NotNull(library);

            var seasons = await library.Seasons(92640);
            foreach (var season in seasons.Media)
            {
                this.output.WriteLine("Title: " + season.Title);
            }

            Assert.NotNull(seasons);
            Assert.True(seasons.Media.Count > 0);
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_GetEpisodesForShow()
        {
            var library = this.fixture.Server.Libraries().Result.Single(c => c.Title == "TV Shows") as ShowLibrary;
            Assert.NotNull(library);

            var seasons = await library.Seasons(92640);

            Assert.NotNull(seasons);
            Assert.True(seasons.Media.Count > 0);

            foreach (var season in seasons.Media)
            {
                this.output.WriteLine("Season Title: " + season.Title);

                var episodes = await library.Episodes(int.Parse(season.RatingKey));

                Assert.NotNull(episodes);
                Assert.True(episodes.Media.Count > 0);

                foreach (var episode in episodes.Media)
                {
                    this.output.WriteLine("Episode Title: " + episode.Title);
                }
            }
        }
    }
