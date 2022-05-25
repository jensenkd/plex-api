namespace Plex.ServerApi.Api
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    public class ApiService : IApiService
    {
        private readonly IPlexRequestsHttpClient httpClient;
        private readonly ILogger<ApiService> logger;

        private static readonly JsonSerializerOptions JsonSerializationSettings = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = false,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiService"/> class.
        /// </summary>
        /// <param name="httpClient">Http Client used for rest calls.</param>
        /// <param name="logger">Logging Instance for application logging.</param>
        public ApiService(
            IPlexRequestsHttpClient httpClient,
            ILogger<ApiService> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        /// <inheritdoc />
        public async Task InvokeApiAsync(ApiRequest request)
        {
            using var httpRequestMessage = CreateHttpRequestMessage(request);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            this.logger.LogDebug($"Calling External Api: {httpRequestMessage.RequestUri}");
            var httpResponse = await this.httpClient.SendAsync(httpRequestMessage);
            this.logger.LogDebug($"Finishing called External Api. Total time: {stopWatch.Elapsed.Milliseconds}ms");

            if (!httpResponse.IsSuccessStatusCode)
            {
                await this.LogApiUnsuccessfulAsync(request, httpResponse);
            }
        }

        /// <inheritdoc />
        public async Task<T> InvokeApiAsync<T>(ApiRequest request)
        {
            using var httpRequestMessage = CreateHttpRequestMessage(request);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            this.logger.LogDebug($"Calling External Api: {httpRequestMessage.RequestUri}");
            var httpResponse = await this.httpClient.SendAsync(httpRequestMessage);
            this.logger.LogDebug($"Finishing called External Api. Total time: {stopWatch.Elapsed.Milliseconds}ms");

            if (!httpResponse.IsSuccessStatusCode)
            {
                await this.LogApiUnsuccessfulAsync(request, httpResponse);
            }
            else
            {
                await this.LogApiSuccessfulAsync(request, httpResponse);
            }

            var contentResponse = await httpResponse.Content.ReadAsStringAsync();

            var response = DeserialiseResponse<T>(httpResponse, contentResponse);

            return response;
        }

        private static T DeserialiseResponse<T>(HttpResponseMessage httpResponse, string contentResponse)
        {
            T response;
            if (httpResponse.Content?.Headers?.ContentType?.MediaType == "application/xml")
            {
                var serializer = new XmlSerializer(typeof(T));
                var reader = new StringReader(contentResponse);
                response = (T)serializer.Deserialize(reader);
            }
            else
            {
                response = JsonSerializer.Deserialize<T>(contentResponse, JsonSerializationSettings);
            }

            return response;
        }

        private static void AddRequestHeaders(HttpRequestMessage httpRequestMessage, Dictionary<string, string> headers)
        {
            foreach (var (key, value) in headers)
            {
                httpRequestMessage.Headers.Add(key, value);
            }
        }

        private static HttpRequestMessage CreateHttpRequestMessage(ApiRequest request)
        {
            var httpRequestMessage = new HttpRequestMessage(request.HttpMethod, request.FullUri);
            AddRequestHeaders(httpRequestMessage, request.RequestHeaders);

            if (request.Body != null)
            {
                SetJsonBody(httpRequestMessage, request.Body);
            }

            return httpRequestMessage;
        }

        private static void SetJsonBody(HttpRequestMessage httpRequestMessage, object body)
        {
            var jsonBody = JsonSerializer.Serialize(body, JsonSerializationSettings);

            httpRequestMessage.Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
            httpRequestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        }

        private async Task LogApiUnsuccessfulAsync(ApiRequest request, HttpResponseMessage httpResponse)
        {
            this.logger.LogInformation($"StatusCode: {httpResponse.StatusCode}. Request Uri: {request.FullUri}");

            var rawResponse = await httpResponse.Content.ReadAsStringAsync();

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(rawResponse);
            }

            //TODO Enable retries and handle different response status codes accordingly
            throw new ApplicationException("Unsuccessful response from 3rd Party API");
        }

        private async Task LogApiSuccessfulAsync(ApiRequest request, HttpResponseMessage httpResponse)
        {
            this.logger.LogInformation($"StatusCode: {httpResponse.StatusCode}. Request Uri: {request.FullUri}");

            var rawResponse = await httpResponse.Content.ReadAsStringAsync();
            this.logger.LogInformation(rawResponse);
        }
    }
}
