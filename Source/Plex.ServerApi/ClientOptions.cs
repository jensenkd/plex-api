namespace Plex.ServerApi
{
    /// <summary>
    /// Plex Client Options.
    /// </summary>
    public class ClientOptions
    {
        /// <summary>
        /// Gets or sets product Code.
        /// </summary>
        public string Product { get; set; } = "Unknown";

        /// <summary>
        /// Gets or sets device Name.
        /// </summary>
        public string DeviceName { get; set; } = "Unknown";

        /// <summary>
        /// Client Id.
        /// </summary>
        public string ClientId { get; set; } = "PlexApi";

        /// <summary>
        /// Version.
        /// </summary>
        public string Version { get; set; } = "v1";

        /// <summary>
        /// Platform.
        /// </summary>
        public string Platform { get; set; } = "Web";
    }
}
