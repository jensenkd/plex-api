using Newtonsoft.Json;

namespace Plex.Api.Models.Status
{
    public class Directory
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}