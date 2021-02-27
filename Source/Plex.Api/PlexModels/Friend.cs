namespace Plex.Api.PlexModels
{
    public class Friend
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public bool Restricted { get; set; }
        public string Thumb { get; set; }
        public string Email { get; set; }
        public bool Home { get; set; }
        public string Status { get; set; }
        public string RestrictionProfile { get; set; }
    }
}
