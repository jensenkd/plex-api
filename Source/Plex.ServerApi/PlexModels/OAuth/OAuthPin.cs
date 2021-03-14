namespace Plex.ServerApi.PlexModels.OAuth
{
    using System;

    /// <summary>
    /// OAuth Pin Object
    /// </summary>
    public class OAuthPin
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Trusted
        /// </summary>
        public bool Trusted { get; set; }

        /// <summary>
        /// Client Identifier
        /// </summary>
        public string ClientIdentifier { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Expires In
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Created At
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Expires At
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Auth Token
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }
    }
}
