namespace Plex.Api.ApiModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Clients.Interfaces;
    using Libraries;
    using PlexModels.Media;

    public class ShowLibrary : LibraryBase
    {
        public ShowLibrary(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
            : base(plexServerClient, plexLibraryClient, server)
        {
        }

        public async Task<MediaContainer> SearchShows(string title, string sort, Dictionary<string, string> filters, int start = 0, int count = 100)
        {
            const string libraryType = "show";
            return await this.Search(title, sort, libraryType, filters, start, count);
        }

        public async Task<MediaContainer> SearchEpisodes(string title, string sort, Dictionary<string, string> filters, int start = 0, int count = 100)
        {
            string libraryType = "episode";
            return await this.Search(title, sort, libraryType, filters, start, count);
        }

        public async Task<MediaContainer> RecentlyAdded(string libraryType = "episode", int start = 0, int count = 100)
        {
            return await this.RecentlyAdded(libraryType, start, count);
        }
    }
}
