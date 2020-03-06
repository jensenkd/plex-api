using System;
using Newtonsoft.Json;

namespace Plex.Api.Models.OAuth
{
    public class OAuthPin
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public string code { get; set; }
        public bool trusted { get; set; }
        public string clientIdentifier { get; set; }
        public Location location { get; set; }
        public int expiresIn { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime expiresAt { get; set; }
        public string authToken { get; set; }
    }

    public class Location
    {
        public string code { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string subdivisions { get; set; }
        public string coordinates { get; set; }
    }

}