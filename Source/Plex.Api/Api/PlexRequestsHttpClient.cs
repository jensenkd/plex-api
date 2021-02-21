using System.Net.Http;
using System.Threading.Tasks;

namespace Plex.Api.Api
{
    /// <summary>
    ///
    /// </summary>
    public class PlexRequestsHttpClient : IPlexRequestsHttpClient
    {
        private readonly HttpClient _client;

        /// <summary>
        ///
        /// </summary>
        public PlexRequestsHttpClient()
        {
         _client = new HttpClient();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _client.SendAsync(request);
        }
    }
}
