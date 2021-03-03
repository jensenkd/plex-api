namespace Plex.Api.Clients
{
    using System.Collections.Generic;

    public static class ClientUtilities
    {
        public static  Dictionary<string, string> GetClientLimitHeaders(int from, int to)
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Container-Start"] = from.ToString(),
                ["X-Plex-Container-Size"] = to.ToString(),
            };

            return plexHeaders;
        }

        public static Dictionary<string, string> GetClientIdentifierHeader(string clientId)
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Client-Identifier"] = clientId
            };
            return plexHeaders;
        }

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
