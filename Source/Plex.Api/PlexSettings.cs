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
        /// Plex Server Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Plex Server Auth Token
        /// </summary>
        public string PlexAuthToken { get; set; }

        /// <summary>
        /// Plex Machine Identifier
        /// </summary>
        public string MachineIdentifier { get; set; }

        /// <summary>
        /// Plex Episode Batch Size
        /// </summary>
        public int EpisodeBatchSize { get; set; }

        /// <summary>
        /// Plex Selected Libraries
        /// </summary>
        public List<PlexSelectedLibraries> PlexSelectedLibraries { get; set; } = new List<PlexSelectedLibraries>();
    }

    /// <summary>
    /// Plex Selected Library
    /// </summary>
    public class PlexSelectedLibraries
    {
        /// <summary>
        /// Plex Library Key
        /// </summary>
        public int Key { get; set; }

        /// <summary>
        /// Plex Library Title
        /// </summary>
        public string Title { get; set; } // Name is for display purposes

        /// <summary>
        /// Plex Library Enabled?
        /// </summary>
        public bool Enabled { get; set; }
    }
}
