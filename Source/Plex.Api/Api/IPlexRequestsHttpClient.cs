using System.Net.Http;
using System.Threading.Tasks;

namespace Plex.Api.Api
{
    /// <summary>
    ///
    /// </summary>
    public interface IPlexRequestsHttpClient
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
