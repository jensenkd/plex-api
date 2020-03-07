using System;
using Plex.Api.Models.Friends;
using Plex.Api.Models.Server;

namespace Plex.Api
{
    public static class UriHelper
    {
        private const string Https = "Https";
        private const string Http = "Http";

        public static Uri ReturnUriFromServerInfo(this string val, ServerInfo serverInfo)
        {
            if (val == null)
            {
                throw new ApplicationSettingsException("The URI is null, please check your settings to make sure you have configured the applications correctly.");
            }
            try
            {
                UriBuilder uri;

                int port = int.Parse(serverInfo.Port);
                bool ssl = string.Equals(serverInfo.Scheme, Https, StringComparison.OrdinalIgnoreCase);

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
        
        public static Uri ReturnUri(this string val)
        {
            if (val == null)
            {
                throw new ApplicationSettingsException("The URI is null, please check your settings to make sure you have configured the applications correctly.");
            }
            try
            {
                UriBuilder uri;

                if (val.StartsWith("http://", StringComparison.Ordinal))
                {
                    uri = new UriBuilder(val);
                }
                else if (val.StartsWith("https://", StringComparison.Ordinal))
                {
                    uri = new UriBuilder(val);
                }
                else if (val.Contains(":"))
                {
                    var split = val.Split(':', '/');
                    int port;
                    int.TryParse(split[1], out port);

                    uri = split.Length == 3
                        ? new UriBuilder(Http, split[0], port, "/" + split[2])
                        : new UriBuilder(Http, split[0], port);
                }
                else
                {
                    uri = new UriBuilder(Http, val);
                }

                return uri.Uri;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        /// <summary>
        /// Returns the URI.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="port">The port.</param>
        /// <param name="ssl">if set to <c>true</c> [SSL].</param>
        /// <param name="subdir">The subdir.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationSettingsException">The URI is null, please check your settings to make sure you have configured the applications correctly.</exception>
        /// <exception cref="System.Exception"></exception>
        public static Uri ReturnUri(this string val, int port, bool ssl = default(bool))
        {
            if (val == null)
            {
                throw new ApplicationSettingsException("The URI is null, please check your settings to make sure you have configured the applications correctly.");
            }
            try
            {
                UriBuilder uri;

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

        public static Uri ReturnUriWithSubDir(this string val, int port, bool ssl, string subDir)
        {
            var uriBuilder = new UriBuilder(val);
            if (ssl)
            {
                uriBuilder.Scheme = Https;
            }
            if (!string.IsNullOrEmpty(subDir))
            {
                uriBuilder.Path = subDir;
            }
            uriBuilder.Port = port;

            return uriBuilder.Uri;
        }
        
    }

    public class ApplicationSettingsException : Exception
    {
        public ApplicationSettingsException(string s) : base(s)
        {
        }
    }
}