using System.Collections.Generic;

namespace Plex.Api.Models
{
    public class Directory
    {
        public Directory()
        {
            Seasons = new List<Directory>();
        }
        
        public bool AllowSync { get; set; }
        public string Art { get; set; }
        public string Composite { get; set; }
        public bool Filters { get; set; }
        public bool Refreshing { get; set; }
        public string Thumb { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Agent { get; set; }
        public string Scanner { get; set; }
        public string Language { get; set; }
        public string Uuid { get; set; }
        public int UpdatedAt { get; set; }
        public int CreatedAt { get; set; }
        public string ProviderId { get; set; }
        public string Guid { get; set; }
        public string LibrarySectionId { get; set; }
        public string LibrarySectionTitle { get; set; }
        public string LibrarySectionUuid { get; set; }
        public string Personal { get; set; }
        public string SourceTitle { get; set; }
        public string RatingKey { get; set; }
        public string Studio { get; set; }
        
        public List<Directory> Seasons { get; set; }
        public List<Genre> Genre { get; set; }
        public List<Role> Role { get; set; }
        public Location[] Location { get; set; }
    }
}