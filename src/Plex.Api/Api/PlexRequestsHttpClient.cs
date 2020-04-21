using System.Net.Http;
using System.Threading.Tasks;

namespace Plex.Api.Api
{
    public class PlexRequestsHttpClient : IPlexRequestsHttpClient
    {
        private readonly HttpClient _client;

        public PlexRequestsHttpClient()
        {
            // Ignore SSL Cert validation
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _client = new HttpClient(httpClientHandler);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _client.SendAsync(request);
        }
    }
}