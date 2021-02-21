using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    /// <summary>
    ///
    /// </summary>
    public class Directory
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("art")]
        public string Art { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("composite")]
        public string Composite { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("filters")]
        public bool Filters { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("refreshing")]
        public bool Refreshing { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("agent")]
        public string Agent { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("scanner")]
        public string Scanner { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public long UpdatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("createdAt")]
        public long CreatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("scannedAt")]
        public int ScannedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("content")]
        public bool Content { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("directory")]
        public bool IsDirectory { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("contentChangedAt")]
        public long ContentChangedAt { get; set; }


        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Location")]
        public Location[] Location { get; set; }
    }
}
