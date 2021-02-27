namespace Plex.Api.PlexModels.Account
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Subscription    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("subscribedAt")]
        public DateTime SubscribedAt { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("paymentService")]
        public string PaymentService { get; set; }

        [JsonPropertyName("plan")]
        public string Plan { get; set; }

        [JsonPropertyName("features")]
        public List<string> Features { get; set; }
    }
}
