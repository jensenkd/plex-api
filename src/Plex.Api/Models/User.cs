using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class PlexAccount
    {
        public User User { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Uuid { get; set; }
        [JsonPropertyName("joined_at")]
        public DateTime JoinedAt { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Thumb { get; set; }
        public bool HasPassword { get; set; }
        [JsonPropertyName("authentication_token")]
        public string AuthenticationToken { get; set; }
        public DateTime ConfirmedAt { get; set; }
        public int? ForumId { get; set; }
        public bool RememberMe { get; set; }
        
        public Subscription Subscription { get; set; }
        public Roles Roles { get; set; }
        
        public List<string> Entitlements { get; set; }
    }
}