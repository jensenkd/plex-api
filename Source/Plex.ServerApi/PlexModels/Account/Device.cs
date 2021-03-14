namespace Plex.ServerApi.PlexModels.Account
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public string LastSeenAt { get; set; }
    }
}
