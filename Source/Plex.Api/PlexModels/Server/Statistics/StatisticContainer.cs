namespace Plex.Api.PlexModels.Server.Statistics
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class StatisticContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("StatisticsResources")]
        public List<StatisticsResource> StatisticsResources { get; set; }
    }
}
