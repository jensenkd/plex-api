using System;
using System.Threading.Tasks;

namespace Kineticmedia.Plex.Api.Ombi
{
    public interface ICacheService
    {
        Task<T> GetOrAdd<T>(string cacheKey, Func<Task<T>> factory, DateTime absoluteExpiration = default(DateTime));
        T GetOrAdd<T>(string cacheKey, Func<T> factory, DateTime absoluteExpiration);
        void Remove(string key);
    }
}