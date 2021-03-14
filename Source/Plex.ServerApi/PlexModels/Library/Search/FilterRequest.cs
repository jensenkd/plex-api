namespace Plex.ServerApi.PlexModels.Library.Search
{
    using System.Collections.Generic;

    public class FilterRequest
    {
        public string Field { get; set; }
        public Operator Operator { get; set; }
        public List<string> Values { get; set; }
    }
}
