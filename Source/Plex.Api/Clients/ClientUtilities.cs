namespace Plex.Api.Clients
{
    using System.Collections.Generic;

    /// <summary>
    ///
    /// </summary>
    public static class ClientUtilities
    {
        /// <summary>
        /// Build Client Limit Headers
        /// </summary>
        /// <param name="from">Start Record</param>
        /// <param name="to">Number of records to return</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetClientLimitHeaders(int from, int to)
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Container-Start"] = from.ToString(), ["X-Plex-Container-Size"] = to.ToString(),
            };

            return plexHeaders;
        }

        /// <summary>
        /// Get Client Identifier Header
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetClientIdentifierHeader(string clientId)
        {
            var plexHeaders = new Dictionary<string, string> {["X-Plex-Client-Identifier"] = clientId};
            return plexHeaders;
        }

        /// <summary>
        /// Not all objects in the Plex listings return the complete list of elements
        /// for the object.  These flags will help pull extra fields
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetLibraryFlagFields()
        {
            var plexFlags = new Dictionary<string, string>
            {
                ["checkFiles"] = "1",
                ["includeAllConcerts"] = "1",
                ["includeBandwidths"] = "1",
                ["includeChapters"] = "1",
                ["includeChildren"] = "1",
                ["includeConcerts"] = "1",
                ["includeExternalMedia"] = "1",
                ["includeExtras"] = "1",
                ["includeFields"] = "thumbBlurHash,artBlurHash",
                ["includeGeolocation"] = "1",
                ["includeLoudnessRamps"] = "1",
                ["includeMarkers"] = "1",
                ["includeOnDeck"] = "1",
                ["includePopularLeaves"] = "1",
                ["includePreferences"] = "1",
                ["includeRelated"] = "1",
                ["includeRelatedCount"] = "1",
                ["includeReviews"] = "1",
                ["includeStations"] = "1",
                ["includeCollections"] = "1",
                ["includeAdvanced"] = "1"
            };
            return plexFlags;
        }

        /// <summary>
        /// Get Client Options Header
        /// </summary>
        /// <param name="clientOptions">Client Options</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetClientMetaHeaders(ClientOptions clientOptions)
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Product"] = clientOptions.Product,
                ["X-Plex-Version"] = clientOptions.Version,
                ["X-Plex-Device"] = clientOptions.DeviceName,
                ["X-Plex-Platform"] = clientOptions.Platform,
            };

            return plexHeaders;
        }
    }
}
