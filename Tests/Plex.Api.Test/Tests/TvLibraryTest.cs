namespace Plex.Api.Test.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using ApiModels;
    using ApiModels.Libraries;
    using ApiModels.Libraries.Filters;
    using Enums;
    using PlexModels.Library;
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
