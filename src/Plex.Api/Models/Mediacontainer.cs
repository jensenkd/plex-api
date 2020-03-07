using System.Collections.Generic;

namespace Plex.Api.Models
{
    public class Mediacontainer
    {
        public int Size { get; set; }
        public int TotalSize { get; set; }
        public bool AllowSync { get; set; }
        public string Identifier { get; set; }
        public string MediaTagPrefix { get; set; }
        public int MediaTagVersion { get; set; }
        public string Title1 { get; set; }
        public string Art { get; set; }
        public int LibrarySectionId { get; set; }
        public string LibrarySectionTitle { get; set; }
        public string LibrarySectionUuid { get; set; }
        public bool Nocache { get; set; }
        public string Thumb { get; set; }
        public string Title2 { get; set; }
        public string ViewGroup { get; set; }
        public int ViewMode { get; set; }
        
        public Metadata[] Metadata { get; set; }
        public List<Directory> Directory { get; set; }
    }
}