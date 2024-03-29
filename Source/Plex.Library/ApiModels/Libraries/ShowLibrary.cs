namespace Plex.Library.ApiModels.Libraries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ServerApi.Clients.Interfaces;
    using ServerApi.Enums;
    using ServerApi.PlexModels.Library.Search;
    using ServerApi.PlexModels.Media;
    using Servers;

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
            await this.Search( title, sort, SearchType.Show, filters, start, count);

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
            await this.Search( title, sort, SearchType.Episode, filters, start, count);

        /// <summary>
        /// Get Seasons for a Show
        /// </summary>
        /// <param name="showId">Rating Key for Show</param>
        /// <returns></returns>
        public async Task<MediaContainer> Seasons(int showId)
        {
            var mediaContainer =
                await this._plexServerClient.GetChildrenMetadataAsync(this._server.AccessToken,
                    this._server.Uri.ToString(), showId);

            return mediaContainer;
        }

        /// <summary>
        /// Get Episodes for a Season for a Show
        /// </summary>
        /// <param name="seasonId">Rating Key for Show Season</param>
        /// <returns></returns>
        public async Task<MediaContainer> Episodes(int seasonId)
        {
            var mediaContainer =
                await this._plexServerClient.GetChildrenMetadataAsync(this._server.AccessToken,
                    this._server.Uri.ToString(), seasonId);

            return mediaContainer;
        }


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
            await this.Search( string.Empty, sort, SearchType.Show, null, start, count);

        /// <summary>
        /// Get All Episodes
        /// </summary>
        /// <param name="sort">Sort field:dir</param>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return (Default 100)</param>
        /// <returns></returns>
        public async Task<MediaContainer> AllEpisodes(string sort, int start = 0, int count = 100) =>
            await this.Search( string.Empty, sort, SearchType.Episode, null, start, count);

    }
}
