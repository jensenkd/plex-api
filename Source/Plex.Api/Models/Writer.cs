namespace Plex.Api.Models
{
    using System.Text.Json.Serialization;
    using Plex.Api.Helpers;

    /// <summary>
    ///
    /// </summary>
    public class Writer
    {
        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Tag { get; set; }
    }
}
