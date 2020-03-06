using System;

namespace Plex.Api
{
    public class ApiOptions
    {
        public string ApplicationName { get; set; } = "Unknown";
        public string DeviceName { get; set; } = "Unknown";
        public Guid ClientId { get; set; } = Guid.NewGuid();
    }
}