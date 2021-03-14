namespace Plex.Api.PlexModels.Library.Search
{
    using System.Collections.Generic;
    using global::Plex.Api.PlexModels.Library;

    public class FilterRequest
    {
        public string Field { get; set; }
        public Operator Operator { get; set; }
        public List<string> Values { get; set; }
    }
}
