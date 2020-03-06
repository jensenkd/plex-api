using System;
using System.Collections.Generic;

namespace Plex.Api
{
    public sealed class PlexSettings
    {
        public bool Enable { get; set; }
        /// <summary>
        /// This is the ClientId for OAuth
        /// </summary>
        public Guid InstallId { get; set; }
        public List<PlexServers> Servers { get; set; }
    }

    public class PlexServers
    {
        public string Name { get; set; }
        public string PlexAuthToken { get; set; }
        public string MachineIdentifier { get; set; }

        public int EpisodeBatchSize { get; set; }

        public List<PlexSelectedLibraries> PlexSelectedLibraries { get; set; } = new List<PlexSelectedLibraries>();
    }
    public class PlexSelectedLibraries
    {
        public int Key { get; set; }
        public string Title { get; set; } // Name is for display purposes
        public bool Enabled { get; set; }
    }
}