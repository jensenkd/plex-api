namespace Plex.Api.ApiModels.Libraries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Clients.Interfaces;
    using Enums;
    using Filters;
    using PlexModels.Media;

    /// <summary>
    ///
    /// </summary>
    public class ShowLibrary : LibraryBase
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="plexServerClient"></param>
        /// <param name="plexLibraryClient"></param>
        /// <param name="server"></param>
        public ShowLibrary(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
            : base(plexServerClient, plexLibraryClient, server)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="includeExtendedMetadata"></param>
        /// <param name="title"></param>
        /// <param name="sort"></param>
        /// <param name="filters"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchShows(bool includeExtendedMetadata, string title, string sort, List<FilterRequest> filters, int start = 0, int count = 100) =>
            await this.Search(includeExtendedMetadata, title, sort, SearchType.Show, filters, start, count);

        /// <summary>
        ///
        /// </summary>
        /// <param name="includeExtendedMetadata"></param>
        /// <param name="title"></param>
        /// <param name="sort"></param>
        /// <param name="filters"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchEpisodes(bool includeExtendedMetadata, string title, string sort, List<FilterRequest> filters, int start = 0, int count = 100) =>
            await this.Search(includeExtendedMetadata, title, sort, SearchType.Episode, filters, start, count);

        /// <summary>
        ///
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<MediaContainer> RecentlyAddedShows(int start = 0, int count = 100) =>
            await this.RecentlyAdded(SearchType.Show, start, count);

        /// <summary>
        ///
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<MediaContainer> RecentlyAddedEpisodes(int start = 0, int count = 100) =>
            await this.RecentlyAdded(SearchType.Episode, start, count);
    }
}
