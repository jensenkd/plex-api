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
        public ShowLibrary(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
            : base(plexServerClient, plexLibraryClient, server)
        {
        }

        /// <summary>
        /// Search Shows
        /// </summary>
        /// <param name="title">Title of Show (optional)</param>
        /// <param name="sort">Sort field:dir</param>
        /// <param name="filters">Filters</param>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return (Default 100)</param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchShows(string title, string sort, List<FilterRequest> filters, int start = 0, int count = 100) =>
            await this.Search(true, title, sort, SearchType.Show, filters, start, count);

        /// <summary>
        /// Search Episodes
        /// </summary>
        /// <param name="title">Title of Episode (optional)</param>
        /// <param name="sort">Sort field:dir</param>
        /// <param name="filters"></param>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return (Default 100)</param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchEpisodes(string title, string sort, List<FilterRequest> filters, int start = 0, int count = 100) =>
            await this.Search(true, title, sort, SearchType.Episode, filters, start, count);

        /// <summary>
        /// Get Recently Added Shows
        /// </summary>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return (Default 100)</param>
        /// <returns></returns>
        public async Task<MediaContainer> RecentlyAddedShows(int start = 0, int count = 100) =>
            await this.RecentlyAdded(SearchType.Show, start, count);

        /// <summary>
        /// Get Recently Added Episodes
        /// </summary>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return (Default 100)</param>
        /// <returns></returns>
        public async Task<MediaContainer> RecentlyAddedEpisodes(int start = 0, int count = 100) =>
            await this.RecentlyAdded(SearchType.Episode, start, count);

        /// <summary>
        /// Get All Shows
        /// </summary>
        /// <param name="sort">Sort field:dir</param>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return (Default 100)</param>
        /// <returns></returns>
        public async Task<MediaContainer> AllShows(string sort, int start = 0, int count = 100) =>
            await this.Search(true, string.Empty, sort, SearchType.Show, null, start, count);

        /// <summary>
        /// Get All Episodes
        /// </summary>
        /// <param name="sort">Sort field:dir</param>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return (Default 100)</param>
        /// <returns></returns>
        public async Task<MediaContainer> AllEpisodes(string sort, int start = 0, int count = 100) =>
            await this.Search(true, string.Empty, sort, SearchType.Episode, null, start, count);

    }
}
