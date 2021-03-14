namespace Plex.ServerApi.PlexModels.Server.Statistics
{
    using System.Text.Json.Serialization;

    public class StatisticsResource
    {
        [JsonPropertyName("timespan")]
        public int Timespan { get; set; }

        [JsonPropertyName("at")]
        public int At { get; set; }

        [JsonPropertyName("hostCpuUtilization")]
        public double HostCpuUtilization { get; set; }

        [JsonPropertyName("processCpuUtilization")]
        public double ProcessCpuUtilization { get; set; }

        [JsonPropertyName("hostMemoryUtilization")]
        public double HostMemoryUtilization { get; set; }

        [JsonPropertyName("processMemoryUtilization")]
        public double ProcessMemoryUtilization { get; set; }
    }
}
