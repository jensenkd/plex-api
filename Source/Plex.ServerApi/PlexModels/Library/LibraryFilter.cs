namespace Plex.ServerApi.PlexModels.Library
{
    using System.Collections.Generic;

    public class LibraryFilter
    {
        public List<string> Types { get; set; } = new List<string>();
        public List<string> Keys { get; set; } = new List<string>();
        public List<string> Titles { get; set; } = new List<string>();
    }
}
