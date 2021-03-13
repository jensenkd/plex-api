namespace Plex.Api.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using ApiModels.Libraries.Filters;

    /// <summary>
    /// Api Request Builder.
    /// </summary>
    public class ApiRequestBuilder
    {
        private readonly string baseUri;
        private readonly string endpoint;
        private readonly HttpMethod httpMethod;
        private readonly Dictionary<string, string> requestHeaders;
        private readonly Dictionary<string, string> contentHeaders;
        private readonly Dictionary<string, string> queryParams;

        private object Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestBuilder"/> class.
        /// </summary>
        /// <param name="baseUri">Base Api Uri.</param>
        /// <param name="endpoint">Api Endpoint.</param>
        /// <param name="httpMethod">Api Http Method.</param>
        public ApiRequestBuilder(string baseUri, string endpoint, HttpMethod httpMethod)
        {
            this.baseUri = baseUri;
            this.endpoint = endpoint;
            this.httpMethod = httpMethod;
            this.requestHeaders = new Dictionary<string, string>();
            this.contentHeaders = new Dictionary<string, string>();
            this.queryParams = new Dictionary<string, string>();
        }

        /// <summary>
        /// Add Request Headers.
        /// </summary>
        /// <param name="headers">Headers Dictionary.</param>
        /// <returns></returns>
        public ApiRequestBuilder AddRequestHeaders(Dictionary<string, string> headers)
        {
            this.AddMultipleHeaders(headers);
            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ApiRequestBuilder AddHeader(string key, string value)
        {
            this.AddSingleHeader(key, value);
            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public ApiRequestBuilder AddPlexToken(string authToken)
        {
            this.AddSingleHeader("X-Plex-Token", authToken);
            return this;
        }

        /// <summary>
        /// Add Query Parameters
        /// </summary>
        /// <param name="queryParameters">Query Parameters</param>
        /// <returns></returns>
        public ApiRequestBuilder AddQueryParams(Dictionary<string, string> queryParameters)
        {
            this.AddMultipleQueryParams(queryParameters);
            return this;
        }

        /// <summary>
        /// Add Query Parameter
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        public ApiRequestBuilder AddQueryParam(string key, string value)
        {
            this.AddSingleQueryParam(key, value);
            return this;
        }

        /// <summary>
        /// Accept Json
        /// </summary>
        /// <returns>Api Request Builder Object</returns>
        public ApiRequestBuilder AcceptJson()
        {
            this.AddHeader("Accept", "application/json");
            return this;
        }

        /// <summary>
        /// Add Json Body
        /// </summary>
        /// <param name="body">Body</param>
        /// <returns>Api Request Builder Oject</returns>
        public ApiRequestBuilder AddJsonBody(object body)
        {
            this.Body = body;
            return this;
        }

        /// <summary>
        /// Add Filter Parameters
        /// </summary>
        /// <param name="filters">Field Filter Requests</param>
        public ApiRequestBuilder AddFilterFields(List<FilterRequest> filters)
        {
            if (filters != null && filters.Any())
            {
                var queryParameters = this.queryParams ?? new Dictionary<string, string>();

                foreach (var item in filters)
                {
                    switch (item.Operator)
                    {
                        case Operator.Is:
                            queryParameters.Add(item.Field, string.Join(",", item.Values));
                            break;
                        case Operator.IsNot:
                            queryParameters.Add(item.Field+"!", string.Join(",", item.Values));
                            break;
                        case Operator.GreaterThan:
                            queryParameters.Add(item.Field+">>", string.Join(",", item.Values));
                            break;
                        case Operator.LessThan:
                            queryParameters.Add(item.Field+"<<", string.Join(",", item.Values));
                            break;
                        case Operator.Contains:
                            queryParameters.Add(item.Field+"=", string.Join(",", item.Values));
                            break;
                        case Operator.NotContains:
                            queryParameters.Add(item.Field+"!=", string.Join(",", item.Values));
                            break;
                        case Operator.BeginsWith:
                            queryParameters.Add(item.Field+"<", string.Join(",", item.Values));
                            break;
                        case Operator.EndsWith:
                            queryParameters.Add(item.Field+">", string.Join(",", item.Values));
                            break;
                        default:
                            throw new ApplicationException("Invalid Operator requested.");
                    }
                }
            }
            return this;
        }

        private void AddSingleHeader(string key, string value)
        {
            var headers = this.requestHeaders ?? new Dictionary<string, string>();

            headers.Add(key, value);
        }

        private void AddMultipleHeaders(Dictionary<string, string> headers)
        {
            foreach (var (key, value) in headers)
            {
                this.AddSingleHeader(key, value);
            }
        }

        private void AddMultipleQueryParams(Dictionary<string, string> queryParameters)
        {
            if (queryParameters != null && queryParameters.Any())
            {
                foreach (var (key, value) in queryParameters)
                {
                    this.AddSingleQueryParam(key, value);
                }
            }
        }

        private void AddSingleQueryParam(string key, string value)
        {
            var queryParameters = this.queryParams ?? new Dictionary<string, string>();

            queryParameters.Add(key, value);
        }

        /// <summary>
        /// Build Api Request
        /// </summary>
        /// <returns>Api Request Object</returns>
        public ApiRequest Build() =>
            new ApiRequest(this.endpoint, this.baseUri, this.httpMethod, this.requestHeaders, this.contentHeaders, this.Body,
                this.queryParams);


    }
}
