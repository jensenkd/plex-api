namespace Plex.Api.ApiModels
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Clients.Interfaces;
    using PlexModels.Library.Search;

    /// <summary>
    /// Library Base Class
    ///  :class:`~plexapi.library.MovieSection`, :class:`~plexapi.library.ShowSection`,
    ///  :class:`~plexapi.library.MusicSection`, :class:`~plexapi.library.PhotoSection`.
    /// </summary>
    public class SectionBase
    {
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("agent")]
        public string Agent { get; set; }

        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        [JsonPropertyName("art")]
        public string Art { get; set; }

        [JsonPropertyName("composite")]
        public string Composite { get; set; }

        [JsonPropertyName("createdAt")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("filters")]
        public string Filters { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("refreshing")]
        public bool Refreshing { get; set; }

        [JsonPropertyName("scanner")]
        public string Scanner { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [JsonPropertyName("type")]
        public string Title { get; set; }

        [JsonPropertyName("title")]
        public string Type { get; set; }

        [JsonPropertyName("updatedAt")]
        public long UpdatedAt { get; set; }


        [JsonPropertyName("Location")]
        public List<string> Locations { get; set; }
    }
}
