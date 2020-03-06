using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Plex.Api
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
        Task<string> GetStringAsync(Uri requestUri);
    }
}