namespace Plex.Api
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Plex Settings Object.
    /// </summary>
    public sealed class PlexSettings
    {
        /// <summary>
        ///
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// This is the ClientId for OAuth.
        /// </summary>
        public Guid InstallId { get; set; }

        /// <summary>
        /// List of Servers.
        /// </summary>
        public List<PlexServers> Servers { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class PlexServers
    {
        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string PlexAuthToken { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MachineIdentifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int EpisodeBatchSize { get; set; }

        /// <summary>
        ///
        /// </summary>
        public List<PlexSelectedLibraries> PlexSelectedLibraries { get; set; } = new List<PlexSelectedLibraries>();
    }

    /// <summary>
    ///
    /// </summary>
    public class PlexSelectedLibraries
    {
        /// <summary>
        ///
        /// </summary>
        public int Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; } // Name is for display purposes

        /// <summary>
        ///
        /// </summary>
        public bool Enabled { get; set; }
    }
}
