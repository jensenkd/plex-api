namespace Plex.Api.PlexModels.OAuth
{
    /// <summary>
    /// Location Object
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Sub Division
        /// </summary>
        public string Subdivisions { get; set; }

        /// <summary>
        /// Coordinates
        /// </summary>
        public string Coordinates { get; set; }
    }
}
