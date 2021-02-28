namespace Plex.Api.Test.Tests
{
    using Xunit;
    using Xunit.Abstractions;

    public class MediaTest : TestBase
    {
        private readonly ITestOutputHelper output;
        public MediaTest(ITestOutputHelper output) =>
            this.output = output;

        [Fact]
        public async void Test_GetPlexServerLibraryMetadata()
        {
            const string libraryKey = "1";
            var metadata = await this.Server.GetLibraryMetadata(libraryKey);
            Assert.NotNull(metadata);
        }

        [Fact]
        public async void Test_GetPlexServerMediaMetadata()
        {
            const string ratingKey = "6401";
            var metadata = await this.Server.GetMediaMetadata(ratingKey);
            Assert.NotNull(metadata);
        }
    }
}
