namespace Plex.Api.Models
{
    /// <summary>
    /// Collection Object
    /// </summary>
    public class Collection
    {
        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Filter
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Tag
        /// </summary>
        public string Tag { get; set; }
    }
}
