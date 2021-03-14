namespace Plex.Library.ApiModels.Libraries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Api.Clients.Interfaces;
    using Api.Enums;
    using Api.PlexModels.Library.Search;
    using Api.PlexModels.Media;
    using Servers;

    public class MusicLibrary : LibraryBase
    {
        public MusicLibrary(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
            : base(plexServerClient, plexLibraryClient, server)
        {
        }

        /// <summary>
        /// Get Albums for this library
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<MediaContainer> Albums(string sort, int start = 0, int count = 100)
        {
            //'/library/sections/{this.Key}/albums'
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Artists for this library
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<MediaContainer> Artists(string sort, int start = 0, int count = 100)
        {
            //'/library/sections/{this.Key}/albums'
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Stations for this Library
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<MediaContainer> Stations(string sort, int start = 0, int count = 100)
        {
            //'/hubs/sections/{this.Key}?includeStations=1'
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search for an Artist.
        /// </summary>
        /// <param name="name">Name of Artist to search for</param>
        /// <param name="sort">Sort order.</param>
        /// <param name="filters">Filters</param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchArtists(string name, string sort, List<FilterRequest> filters,
            int start = 0, int count = 100) =>
            await this.Search(true, name, sort, SearchType.Artist, filters, start, count);

        /// <summary>
        /// Search for an Album.
        /// </summary>
        /// <param name="title">Title to search for</param>
        /// <param name="sort">Sort order.</param>
        /// <param name="filters">Filters</param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchAlbums(string title, string sort, List<FilterRequest> filters,
            int start = 0, int count = 100) =>
            await this.Search(true, title, sort, SearchType.Album, filters, start, count);

        /// <summary>
        /// Search for a track.
        /// </summary>
        /// <param name="title">Title to search for</param>
        /// <param name="sort">Sort order.</param>
        /// <param name="filters">Filters</param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchTracks(string title, string sort, List<FilterRequest> filters,
            int start = 0, int count = 100) =>
            await this.Search(true, title, sort, SearchType.Track, filters, start, count);

        /// <summary>
        /// Get All Artists
        /// </summary>
        /// <param name="sort">Sort field:dir</param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        public async Task<MediaContainer> AllArtists(string sort, int start = 0, int count = 100) =>
            await this.Search(true, string.Empty, sort, SearchType.Artist, null, start, count);

        /// <summary>
        /// Get All Albums
        /// </summary>
        /// <param name="sort">Sort field:dir</param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        public async Task<MediaContainer> AllAlbums(string sort, int start = 0, int count = 100) =>
            await this.Search(true, string.Empty, sort, SearchType.Album, null, start, count);

        /// <summary>
        /// Get All Tracks
        /// </summary>
        /// <param name="sort">Sort field:dir</param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        public async Task<MediaContainer> AllTracks(string sort, int start = 0, int count = 100) =>
            await this.Search(true, string.Empty, sort, SearchType.Track, null, start, count);
    }
}
