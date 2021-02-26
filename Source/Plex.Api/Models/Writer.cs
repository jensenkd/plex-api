namespace Plex.Api.Models
{
    using System.Text.Json.Serialization;
    using Helpers;

    /// <summary>
    /// Writer Object
    /// </summary>
    public class Writer
    {
        /// <summary>
        /// Writer Id
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

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
