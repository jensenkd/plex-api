namespace Plex.ServerApi.PlexModels.Watchlist;

using System.Text.Json.Serialization;

public class WatchlistMetadata
{
    public string Art { get; set; }
    public string Banner { get; set; }
    public string Guid { get; set; }
    public string Key { get; set; }
    public string PrimaryExtraKey { get; set; }
    public decimal? Rating { get; set; }
    public string RatingKey { get; set; }
    public string Studio { get; set; }
    public string Type { get; set; }
    public string Thumb { get; set; }
    public long AddedAt { get; set; }
    public long Duration { get; set; }
    [JsonPropertyName("publicPagesURL")]
    public string PublicPagesUrl { get; set; }
    public string Slug { get; set; }
    public bool UserState { get; set; }
    public string Title { get; set; }
    public string ContentRating { get; set; }
    public string OriginallyAvailableAt { get; set; }
    public int Year { get; set; }
    public decimal? AudienceRating { get; set; }
    public string AudienceRatingImage { get; set; }
    public long? ImdbRatingCount { get; set; }

    [JsonPropertyName("Image")]
    public WatchlistMetadataImage[] Images { get; set; }

}
