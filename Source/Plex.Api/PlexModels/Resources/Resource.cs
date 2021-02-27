namespace Plex.Api.PlexModels.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Resource
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("productVersion")]
        public string ProductVersion { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("platformVersion")]
        public string PlatformVersion { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }

        [JsonPropertyName("clientIdentifier")]
        public string ClientIdentifier { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("lastSeenAt")]
        public DateTime LastSeenAt { get; set; }

        [JsonPropertyName("provides")]
        public string Provides { get; set; }

        [JsonPropertyName("ownerId")]
        public int? OwnerId { get; set; }

        [JsonPropertyName("sourceTitle")]
        public string SourceTitle { get; set; }

        [JsonPropertyName("publicAddress")]
        public string PublicAddress { get; set; }

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("owned")]
        public bool Owned { get; set; }

        [JsonPropertyName("home")]
        public bool Home { get; set; }

        [JsonPropertyName("synced")]
        public bool Synced { get; set; }

        [JsonPropertyName("relay")]
        public bool Relay { get; set; }

        [JsonPropertyName("presence")]
        public bool Presence { get; set; }

        [JsonPropertyName("httpsRequired")]
        public bool HttpsRequired { get; set; }

        [JsonPropertyName("publicAddressMatches")]
        public bool PublicAddressMatches { get; set; }

        [JsonPropertyName("dnsRebindingProtection")]
        public bool DnsRebindingProtection { get; set; }

        [JsonPropertyName("natLoopbackSupported")]
        public bool NatLoopbackSupported { get; set; }

        [JsonPropertyName("connections")]
        public List<Connection> Connections { get; set; }
    }
}
