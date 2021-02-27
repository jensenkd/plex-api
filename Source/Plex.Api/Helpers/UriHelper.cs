namespace Plex.Api.Helpers
{
    using System;
    using Models.Server;

    /// <summary>
    /// Uri Helper Object
    /// </summary>
    public static class UriHelper
    {
        private const string Https = "Https";
        private const string Http = "Http";

        /// <summary>
        /// Get Url from Server Info
        /// </summary>
        /// <param name="val"></param>
        /// <param name="server">Server Object</param>
        /// <returns>Uri of Server</returns>
        /// <exception cref="ApplicationException">Application Exception</exception>
        /// <exception cref="Exception">Exception</exception>
        public static Uri ReturnUriFromServerInfo(this string val, Server server)
        {
            if (val == null)
            {
                throw new ApplicationException("The URI is null, please check your settings to make sure you have configured the applications correctly.");
            }
            try
            {
                UriBuilder uri;

                var port = int.Parse(server.Port);
                var ssl = string.Equals(server.Scheme, Https, StringComparison.OrdinalIgnoreCase);

                if (val.StartsWith("http://", StringComparison.Ordinal))
                {
                    var split = val.Split('/');
                    uri = split.Length >= 4 ? new UriBuilder(Http, split[2], port, "/" + split[3]) : new UriBuilder(new Uri($"{val}:{port}"));
                }
                else if (val.StartsWith("https://", StringComparison.Ordinal))
                {
                    var split = val.Split('/');
                    uri = split.Length >= 4
                        ? new UriBuilder(Https, split[2], port, "/" + split[3])
                        : new UriBuilder(Https, split[2], port);
                }
                else if (ssl)
                {
                    uri = new UriBuilder(Https, val, port);
                }
                else
                {
                    uri = new UriBuilder(Http, val, port);
                }

                return uri.Uri;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }
    }
}
