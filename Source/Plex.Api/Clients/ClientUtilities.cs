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
        public static  Dictionary<string, string> GetClientLimitHeaders(int from, int to)
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Container-Start"] = from.ToString(),
                ["X-Plex-Container-Size"] = to.ToString(),
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
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Client-Identifier"] = clientId
            };
            return plexHeaders;
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
