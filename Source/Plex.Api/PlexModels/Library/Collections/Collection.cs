namespace Plex.Api.PlexModels.Library.Collections
{
    using System.Text.Json.Serialization;

    public class Collection
    {
        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("guid")]
        public string Guid { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("contentRating")]
        public string ContentRating { get; set; }

        [JsonPropertyName("subtype")]
        public string Subtype { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("ratingCount")]
        public int RatingCount { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [JsonPropertyName("addedAt")]
        public int AddedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public int UpdatedAt { get; set; }

        [JsonPropertyName("childCount")]
        public string ChildCount { get; set; }

        [JsonPropertyName("collectionMode")]
        public string CollectionMode { get; set; }

        [JsonPropertyName("collectionSort")]
        public string CollectionSort { get; set; }

        [JsonPropertyName("maxYear")]
        public string MaxYear { get; set; }

        [JsonPropertyName("minYear")]
        public string MinYear { get; set; }

        [JsonPropertyName("titleSort")]
        public string TitleSort { get; set; }
    }

}
