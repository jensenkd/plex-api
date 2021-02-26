using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    /// <summary>
    /// Directory Object
    /// </summary>
    public class Directory
    {
        /// <summary>
        /// Allow Sync?
        /// </summary>
        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        /// <summary>
        /// Art
        /// </summary>
        [JsonPropertyName("art")]
        public string Art { get; set; }

        /// <summary>
        /// Composite
        /// </summary>
        [JsonPropertyName("composite")]
        public string Composite { get; set; }

        /// <summary>
        /// Filters?
        /// </summary>
        [JsonPropertyName("filters")]
        public bool Filters { get; set; }

        /// <summary>
        /// Refreshing?
        /// </summary>
        [JsonPropertyName("refreshing")]
        public bool Refreshing { get; set; }

        /// <summary>
        /// Thumbnail
        /// </summary>
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Agent
        /// </summary>
        [JsonPropertyName("agent")]
        public string Agent { get; set; }

        /// <summary>
        /// Scanner
        /// </summary>
        [JsonPropertyName("scanner")]
        public string Scanner { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// Uuid
        /// </summary>
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// Updated At
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public long UpdatedAt { get; set; }

        /// <summary>
        /// Created At
        /// </summary>
        [JsonPropertyName("createdAt")]
        public long CreatedAt { get; set; }

        /// <summary>
        /// Scanned At
        /// </summary>
        [JsonPropertyName("scannedAt")]
        public int ScannedAt { get; set; }

        /// <summary>
        /// Content?
        /// </summary>
        [JsonPropertyName("content")]
        public bool Content { get; set; }

        /// <summary>
        /// Is Directory?
        /// </summary>
        [JsonPropertyName("directory")]
        public bool IsDirectory { get; set; }

        /// <summary>
        /// Content Changed At
        /// </summary>
        [JsonPropertyName("contentChangedAt")]
        public long ContentChangedAt { get; set; }


        /// <summary>
        /// Lcation Items
        /// </summary>
        [JsonPropertyName("Location")]
        public Location[] Location { get; set; }
    }
}
