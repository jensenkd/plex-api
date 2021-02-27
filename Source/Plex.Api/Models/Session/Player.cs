namespace Plex.Api.Models.Session
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Player Object
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Address
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Device
        /// </summary>
        [JsonPropertyName("device")]
        public string Device { get; set; }

        /// <summary>
        /// Machine Identifier
        /// </summary>
        [JsonPropertyName("machineIdentifier")]
        public string MachineIdentifier { get; set; }

        /// <summary>
        /// Model
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Platform
        /// </summary>
        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        /// <summary>
        /// Platform Version
        /// </summary>
        [JsonPropertyName("platformVersion")]
        public string PlatformVersion { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        [JsonPropertyName("product")]
        public string Product { get; set; }

        /// <summary>
        /// Profile
        /// </summary>
        [JsonPropertyName("profile")]
        public string Profile { get; set; }

        /// <summary>
        /// Remote Public Address
        /// </summary>
        [JsonPropertyName("remotePublicAddress")]
        public string RemotePublicAddress { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Vendor
        /// </summary>
        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        /// Is Local?
        /// </summary>
        [JsonPropertyName("local")]
        public bool Local { get; set; }

        /// <summary>
        /// Is Relayed?
        /// </summary>
        [JsonPropertyName("relayed")]
        public bool Relayed { get; set; }

        /// <summary>
        /// Is Secure?
        /// </summary>
        [JsonPropertyName("secure")]
        public bool Secure { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("userID")]
        public long UserId { get; set; }
    }

}
