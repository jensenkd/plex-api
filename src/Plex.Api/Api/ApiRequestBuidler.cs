using System.Collections.Generic;
using System.Net.Http;

namespace Plex.Api.Api
{
   public class ApiRequestBuilder
    {
        private readonly string _baseUri;
        private readonly string _endpoint;
        private readonly HttpMethod _httpMethod;
        private readonly Dictionary<string, string> _requestHeaders;
        private readonly Dictionary<string, string> _contentHeaders;
        private readonly Dictionary<string, string> _queryParams;
        private object Body { get; set; }

        public ApiRequestBuilder(string baseUri, string endpoint, HttpMethod httpMethod)
        {
            _baseUri = baseUri;
            _endpoint = endpoint;
            _httpMethod = httpMethod;
            _requestHeaders = new Dictionary<string, string>();
            _contentHeaders = new Dictionary<string, string>();
            _queryParams = new Dictionary<string, string>();
        }

        public ApiRequestBuilder AddRequestHeaders(Dictionary<string, string> headers)
        {
            AddMultipleHeaders(headers);
            return this;
        }

        public ApiRequestBuilder AddHeader(string key, string value)
        {
            AddSingleHeader(key, value);
            return this;
        }

        public ApiRequestBuilder AddPlexToken(string authToken)
        {
            AddSingleHeader("X-Plex-Token", authToken);
            return this;
        }

        public ApiRequestBuilder AddQueryParams(Dictionary<string, string> queryParams)
        {
            AddMultipleQueryParams(queryParams);
            return this;
        }

        public ApiRequestBuilder AddQueryParam(string key, string value)
        {
            AddSingleQueryParam(key, value);
            return this;
        }

        public ApiRequestBuilder AcceptJson()
        {
            AddHeader("Accept", "application/json");
            return this;
        }

        public ApiRequestBuilder AddJsonBody(object body)
        {
            Body = body;
            return this;
        }

        private void AddSingleHeader(string key, string value)
        {
            var headers = _requestHeaders ?? new Dictionary<string, string>();

            headers.Add(key, value);
        }

        private void AddMultipleHeaders(Dictionary<string, string> headers)
        {
            foreach (var (key, value) in headers)
            {
                AddSingleHeader(key, value);
            }
        }

        private void AddMultipleQueryParams(Dictionary<string, string> queryParams)
        {
            foreach (var (key, value) in queryParams)
            {
                AddSingleQueryParam(key, value);
            }
        }

        private void AddSingleQueryParam(string key, string value)
        {
            var queryParams = _queryParams ?? new Dictionary<string, string>();

            queryParams.Add(key, value);
        }

        public ApiRequest Build()
        {
            return new ApiRequest(_endpoint, _baseUri, _httpMethod, _requestHeaders, _contentHeaders, Body, _queryParams);
        }
    }
}