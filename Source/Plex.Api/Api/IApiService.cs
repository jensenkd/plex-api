using System.Threading.Tasks;

namespace Plex.Api.Api
{
    /// <summary>
    ///
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task InvokeApiAsync(ApiRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> InvokeApiAsync<T>(ApiRequest request);
    }
}
