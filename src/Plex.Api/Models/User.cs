using System.Collections.Generic;
using Newtonsoft.Json;

namespace Plex.Api.Models
{
    public class PlexAccount
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        
        [JsonProperty("joined_at")]
        public string JoinedAt { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("thumb")]
        public string Thumb { get; set; }
        
        [JsonProperty("hasPassword")]
        public string HasPassword { get; set; }
        
        [JsonProperty("authentication_token")]
        public string AuthenticationToken { get; set; }
        
        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }
        
        [JsonProperty("roles")]
        public Roles Roles { get; set; }
        
        [JsonProperty("entitlements")]
        public List<string> Entitlements { get; set; }
        
        [JsonProperty("confirmed_at")]
        public object ConfirmedAt { get; set; }
        
        [JsonProperty("forum_id")]
        public int ForumId { get; set; }
    }
}