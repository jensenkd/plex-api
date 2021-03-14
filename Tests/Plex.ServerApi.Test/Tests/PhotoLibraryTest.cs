namespace Plex.ServerApi.Test.Tests
{
    using Xunit;
    using Xunit.Abstractions;

    public class PhotoLibraryTest : IClassFixture<PlexFixture>
    {
        private readonly PlexFixture fixture;
        private readonly ITestOutputHelper output;

        public PhotoLibraryTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.fixture = fixture;
        }
    }
}
