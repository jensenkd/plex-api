namespace Plex.Api.Test.Tests
{
    using Xunit;
    using Xunit.Abstractions;

    public class MediaTest : IClassFixture<PlexFixture>
    {
        private readonly PlexFixture fixture;
        private readonly ITestOutputHelper output;

        public MediaTest(ITestOutputHelper output, PlexFixture fixture)
        {
            this.output = output;
            this.fixture = fixture;
        }

    }
}
