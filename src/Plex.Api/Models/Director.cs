using Newtonsoft.Json;

namespace Kineticmedia.Plex.Api.Models
{
    public class Director
    {
        [JsonProperty("id")]
        public int id { get; set; }
        public string filter { get; set; }
        public string tag { get; set; }
    }
}