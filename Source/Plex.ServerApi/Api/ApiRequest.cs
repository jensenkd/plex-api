namespace Plex.ServerApi.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;

    /// <summary>
    /// Class for issuing Api Requests to Plex Server.
    /// </summary>
    public class ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        /// <param name="endpoint">Endpoint of api request.</param>
        /// <param name="baseUri">Base Uri for api request.</param>
        /// <param name="httpMethod">Http Method to be used for api request.</param>
        /// <param name="requestHeaders">Request Headers for api request.</param>
        /// <param name="contentHeaders">Content Headers for api request.</param>
        /// <param name="body">Body of api request.</param>
        /// <param name="queryParams">Query parameters for api request.</param>
        public ApiRequest(string endpoint, string baseUri, HttpMethod httpMethod, Dictionary<string, string> requestHeaders,
            Dictionary<string, string> contentHeaders, object body, Dictionary<string, string> queryParams)
        {
            this.Endpoint = endpoint;
            this.BaseUri = baseUri;
            this.HttpMethod = httpMethod;
            this.RequestHeaders = requestHeaders;
            this.ContentHeaders = contentHeaders ?? throw new ArgumentNullException(nameof(contentHeaders));
            this.Body = body;
            this.QueryParams = queryParams;
        }

        /// <summary>
        /// Gets endpoint of api request.
        /// </summary>
        private string Endpoint { get; }

        private string BaseUri { get; }

        /// <summary>
        /// Http Method for Api Request.
        /// </summary>
        public HttpMethod HttpMethod { get; }

        /// <summary>
        /// Request Headers of Api Request.
        /// </summary>
        public Dictionary<string, string> RequestHeaders { get; }

        /// <summary>
        /// Content Headers of Api Reqeuest.
        /// </summary>
        private Dictionary<string, string> ContentHeaders { get; }

        /// <summary>
        /// Query Parameters of Api Request.
        /// </summary>
        private Dictionary<string, string> QueryParams { get; }

        /// <summary>
        /// Body of Api Request.
        /// </summary>
        public object Body { get; }

        /// <summary>
        /// Get Full Uri of Endpoint.
        /// </summary>
        public string FullUri
        {
            get
            {
                var uriBuilder = new StringBuilder();

                if (!string.IsNullOrEmpty(this.BaseUri))
                {
                    uriBuilder.Append(this.BaseUri.EndsWith("/") ? this.BaseUri : $"{this.BaseUri}/");
                }

                if (!string.IsNullOrEmpty(this.Endpoint))
                {
                    uriBuilder.Append(this.Endpoint.StartsWith("/") ? this.Endpoint.Substring(1) : this.Endpoint);
                }

                this.AddQueryParams(uriBuilder);

                return uriBuilder.ToString();
            }
        }

        /// <summary>
        /// Add Querystring Parameters
        /// </summary>
        /// <param name="uriBuilder"></param>
        private void AddQueryParams(StringBuilder uriBuilder)
        {
            if (!this.QueryParams.Any())
            {
                return;
            }

            if (!uriBuilder.ToString().Contains("?"))
            {
                uriBuilder.Append("?");
            }

            for (var i = 0; i < this.QueryParams.Count; i++)
            {
                var (key, value) = this.QueryParams.ElementAt(i);

                uriBuilder.Append($"{key}={value}");

                var isLast = i == this.QueryParams.Count - 1;

                if (!isLast)
                {
                    uriBuilder.Append("&");
                }
            }
        }
    }
}
