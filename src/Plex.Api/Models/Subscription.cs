namespace Plex.Api.Models
{
    public class Subscription
    {
        public bool Active { get; set; }
        public string Status { get; set; }
        public object Plan { get; set; }
        public object Features { get; set; }
    }
}