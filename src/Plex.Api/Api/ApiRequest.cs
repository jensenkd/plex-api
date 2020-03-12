using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;

namespace Plex.Api.Api
{
    public class ApiRequest
    {
        public ApiRequest(string endpoint, string baseUri, HttpMethod httpMethod,
            Dictionary<string, string> requestHeaders, Dictionary<string, string> contentHeaders, object body,
            Dictionary<string, string> queryParams)
        {
            Endpoint = endpoint;
            BaseUri = baseUri;
            HttpMethod = httpMethod;
            RequestHeaders = requestHeaders;
            ContentHeaders = contentHeaders;
            Body = body;
            QueryParams = queryParams;
        }

        public string Endpoint { get; }
        public string BaseUri { get; }
        public HttpMethod HttpMethod { get; }
        public Dictionary<string, string> RequestHeaders { get; }
        public Dictionary<string, string> ContentHeaders { get; }
        public Dictionary<string, string> QueryParams { get; }
        public object Body { get; }

        public string FullUri
        {
            get
            {
                var uriBuilder = new StringBuilder();

                if (!string.IsNullOrEmpty(BaseUri))
                {
                    uriBuilder.Append(BaseUri.EndsWith("/") ? BaseUri : $"{BaseUri}/");
                }

                if (!string.IsNullOrEmpty(Endpoint))
                {
                    uriBuilder.Append(Endpoint.StartsWith("/") ? Endpoint.Skip(1) : Endpoint);
                }

                AddQueryParams(uriBuilder);

                return uriBuilder.ToString();
            }
        }

        private void AddQueryParams(StringBuilder uriBuilder)
        {
            if (!QueryParams.Any())
            {
                return;
            }

            if (!uriBuilder.ToString().Contains("?"))
            {
                uriBuilder.Append("?");
            }

            for (var i = 0; i < QueryParams.Count; i++)
            {
                var (key, value) = QueryParams.ElementAt(i);

                uriBuilder.Append($"{key}={value}");

                var isLast = i == QueryParams.Count - 1;

                if (!isLast)
                {
                    uriBuilder.Append("&");
                }
            }
        }
    }
}