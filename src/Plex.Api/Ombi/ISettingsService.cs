using System;
using System.Threading.Tasks;

namespace Kineticmedia.Plex.Api.Ombi
{
    public interface ISettingsService<T> : IDisposable
    {
        T GetSettings();
        Task<T> GetSettingsAsync();
        bool SaveSettings(T model);
        Task<bool> SaveSettingsAsync(T model);
        void Delete(T model);
        Task DeleteAsync(T model);
        void ClearCache();
    }
}