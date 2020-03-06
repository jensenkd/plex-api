using Newtonsoft.Json;

namespace Plex.Api.Models
{
    public class Director
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}