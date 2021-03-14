namespace Plex.ServerApi.Test.Tests
{
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
    }
}
