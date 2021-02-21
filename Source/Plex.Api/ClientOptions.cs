using System;

namespace Plex.Api
{
    /// <summary>
    ///
    /// </summary>
    public class ClientOptions
    {
        /// <summary>
        ///
        /// </summary>
        public string Product { get; set; } = "Unknown";

        /// <summary>
        ///
        /// </summary>
        public string DeviceName { get; set; } = "Unknown";

        /// <summary>
        ///
        /// </summary>
        public string ClientId { get; set; } = "PlexApi";

        /// <summary>
        ///
        /// </summary>
        public string Version { get; set; } = "v1";

        /// <summary>
        ///
        /// </summary>
        public string Platform { get; set; } = "Web";
    }
}
