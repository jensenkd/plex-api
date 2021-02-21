namespace Plex.Api.Models.OAuth
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public class OAuthPin
    {
        /// <summary>
        ///
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool Trusted { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ClientIdentifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class Location
    {
        /// <summary>
        ///
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Subdivisions { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Coordinates { get; set; }
    }
}
