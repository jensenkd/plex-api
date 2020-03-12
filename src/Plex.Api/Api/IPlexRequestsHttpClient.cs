using System.Net.Http;
using System.Threading.Tasks;

namespace Plex.Api.Api
{
    public interface IPlexRequestsHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}