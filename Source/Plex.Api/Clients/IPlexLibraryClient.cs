namespace Plex.Api.Clients
{
    using System.Threading.Tasks;
    using PlexModels.Hubs;
    using PlexModels.Library.Search;
    using PlexModels.Media;

    /// <summary>
    /// Inteface for Plex Library Client
    /// </summary>
    public interface IPlexLibraryClient
    {
        /// <summary>
        /// Empty Trash on Server for given Library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        Task EmptyTrash(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Scan library for newly added items
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        Task ScanForNewItems(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Cancels library scan for given library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        Task CancelScanForNewItems(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Return all the Filter Options for a given Library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        /// <returns></returns>
        Task<FilterContainer> GetSearchFilters(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Hub Search across everything
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="title">Title</param>
        /// <returns></returns>
        Task<HubMediaContainer> HubLibrarySearch(string authToken, string plexServerHost, string title);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="title">General string query to search for (optional).</param>
        /// <param name="libraryKey">Library Key</param>
        /// <param name="sort">column:dir; column can be any of {addedAt, originallyAvailableAt, lastViewedAt,
        /// titleSort, rating, mediaHeight, duration}. dir can be asc or desc (optional).</param>
        /// <param name="libraryType">Filter results to a spcifiec libtype (movie, show, episode, artist,
        /// album, track; optional).</param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns>MediaContainer</returns>
        Task<MediaContainer> LibrarySearch(string authToken, string plexServerHost, string title, string libraryKey, string sort, string libraryType, int start = 0, int count = 100);


    }
}
