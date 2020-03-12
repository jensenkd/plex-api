using System.Net.Http;
using System.Threading.Tasks;

namespace Plex.Api.Api
{
    public class PlexRequestsHttpClient : IPlexRequestsHttpClient
    {
        private readonly HttpClient _client;

        public PlexRequestsHttpClient()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _client.SendAsync(request);
        }
    }
}