using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;

using Polly;

namespace Plex.Api.Helpers
{
      public class Api : IApi
    {
        public Api(ILogger<Api> log, IGenericHttpClient client)
        {
            Logger = log;
            _client = client;
        }

        private ILogger<Api> Logger { get; }
        private readonly IGenericHttpClient _client;

        private static readonly JsonSerializerOptions Settings = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task<T> Request<T>(Request request)
        {
            using (var httpRequestMessage = new HttpRequestMessage(request.HttpMethod, request.FullUri))
            {
                AddHeadersBody(request, httpRequestMessage);

                var httpResponseMessage = await _client.SendAsync(httpRequestMessage);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    if (!request.IgnoreErrors)
                    {
                        await LogError(request, httpResponseMessage);
                    }

                    if (request.Retry)
                    {

                        var result = Policy
                            .Handle<HttpRequestException>()
                            .OrResult<HttpResponseMessage>(r => request.StatusCodeToRetry.Contains(r.StatusCode))
                            .WaitAndRetryAsync(new[]
                            {
                                TimeSpan.FromSeconds(10),
                            }, (exception, timeSpan, context) =>
                            {

                                Logger.LogError(LoggingEvents.Api,
                                    $"Retrying RequestUri: {request.FullUri} Because we got Status Code: {exception?.Result?.StatusCode}");
                            });

                        httpResponseMessage = await result.ExecuteAsync(async () =>
                        {
                            using (var req = await httpRequestMessage.Clone())
                            {
                                return await _client.SendAsync(req);
                            }
                        });
                    }
                }

                // do something with the response
                var receivedString = await httpResponseMessage.Content.ReadAsStringAsync();
                LogDebugContent(receivedString);
                if (request.ContentType == ContentType.Json)
                {
                    request.OnBeforeDeserialization?.Invoke(receivedString);
                    return  JsonSerializer.Deserialize<T>(receivedString, Settings);
                }
                else
                {
                    // XML
                    return DeserializeXml<T>(receivedString);
                }
            }

        }

        public T DeserializeXml<T>(string receivedString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(receivedString);
            var value = (T) serializer.Deserialize(reader);
            return value;
        }

        public async Task<string> RequestContent(Request request)
        {
            using (var httpRequestMessage = new HttpRequestMessage(request.HttpMethod, request.FullUri))
            {
                AddHeadersBody(request, httpRequestMessage);

                var httpResponseMessage = await _client.SendAsync(httpRequestMessage);
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    if (!request.IgnoreErrors)
                    {
                        await LogError(request, httpResponseMessage);
                    }
                }
                // do something with the response
                var data = httpResponseMessage.Content;
                await LogDebugContent(httpResponseMessage);
                return await data.ReadAsStringAsync();
            }

        }

        public async Task Request(Request request)
        {
            using (var httpRequestMessage = new HttpRequestMessage(request.HttpMethod, request.FullUri))
            {
                AddHeadersBody(request, httpRequestMessage);
                var httpResponseMessage = await _client.SendAsync(httpRequestMessage);
                await LogDebugContent(httpResponseMessage);
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    if (!request.IgnoreErrors)
                    {
                        await LogError(request, httpResponseMessage);
                    }
                }
            }
        }

        private void AddHeadersBody(Request request, HttpRequestMessage httpRequestMessage)
        {
            // Add the Json Body
            if (request.JsonBody != null)
            {
                LogDebugContent("REQUEST: " + request.JsonBody);
                httpRequestMessage.Content = new JsonContent(request.JsonBody);
                httpRequestMessage.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/json"); // Emby connect fails if we have the charset in the header
            }

            // Add headers
            foreach (var header in request.Headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }
        }

        private async Task LogError(Request request, HttpResponseMessage httpResponseMessage)
        {
            Logger.LogError(LoggingEvents.Api,
                $"StatusCode: {httpResponseMessage.StatusCode}, Reason: {httpResponseMessage.ReasonPhrase}, RequestUri: {request.FullUri}");
            await LogDebugContent(httpResponseMessage);
        }

        private async Task LogDebugContent(HttpResponseMessage message)
        {
            if (Logger.IsEnabled(LogLevel.Debug))
            {
                var content = await message.Content.ReadAsStringAsync();
                Logger.LogDebug(content);
            }
        }

        private void LogDebugContent(string message)
        {
            if (Logger.IsEnabled(LogLevel.Debug))
            {
                Logger.LogDebug(message);
            }
        }
    }
}