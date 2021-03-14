namespace Plex.ServerApi.Helpers
{
    using System;

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
        /// <param name="host">Server Host</param>
        /// <param name="port">Server Port</param>
        /// <param name="scheme">Url Scheme</param>
        /// <returns>Uri of Server</returns>
        /// <exception cref="ApplicationException">Application Exception</exception>
        /// <exception cref="Exception">Exception</exception>
        public static Uri ReturnUriFromServerInfo(this string host, int port, string scheme)
        {
            if (host == null)
            {
                throw new ApplicationException("The URI is null, please check your settings to make sure you have configured the applications correctly.");
            }

            try
            {
                UriBuilder uri;

                var ssl = string.Equals(scheme, Https, StringComparison.OrdinalIgnoreCase);

                if (host.StartsWith("http://", StringComparison.Ordinal))
                {
                    var split = host.Split('/');
                    uri = split.Length >= 4 ? new UriBuilder(Http, split[2], port, "/" + split[3]) : new UriBuilder(new Uri($"{host}:{port}"));
                }
                else if (host.StartsWith("https://", StringComparison.Ordinal))
                {
                    var split = host.Split('/');
                    uri = split.Length >= 4
                        ? new UriBuilder(Https, split[2], port, "/" + split[3])
                        : new UriBuilder(Https, split[2], port);
                }
                else if (ssl)
                {
                    uri = new UriBuilder(Https, host, port);
                }
                else
                {
                    uri = new UriBuilder(Http, host, port);
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
