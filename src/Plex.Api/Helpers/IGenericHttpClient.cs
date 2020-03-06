using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Plex.Api.Helpers
{
    public interface IGenericHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
        Task<string> GetStringAsync(Uri requestUri);
    }
}