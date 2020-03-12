using System.Threading.Tasks;

namespace Plex.Api.Api
{
    public interface IApiService
    {
        Task InvokeApiAsync(ApiRequest request);
        Task<T> InvokeApiAsync<T>(ApiRequest request);
    }
}