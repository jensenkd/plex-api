namespace Plex.Api.Api
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Plex Request Http Client.
    /// </summary>
    public interface IPlexRequestsHttpClient
    {
        /// <summary>
        /// Send Request Message to Http Client Endpoint.
        /// </summary>
        /// <param name="request">Http Request Message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
