namespace Plex.ServerApi.Api
{
    using System.Threading.Tasks;

    /// <summary>
    /// Api Service Interface.
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Invoke Api.
        /// </summary>
        /// <param name="request">Api Request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task InvokeApiAsync(ApiRequest request);

        /// <summary>
        /// Invoke Api for Type.
        /// </summary>
        /// <param name="request">Api Request.</param>
        /// <typeparam name="T">Type.</typeparam>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<T> InvokeApiAsync<T>(ApiRequest request);
    }
}
