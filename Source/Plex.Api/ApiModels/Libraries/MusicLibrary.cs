namespace Plex.Api.ApiModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Clients.Interfaces;
    using Enums;
    using Libraries;
    using Libraries.Filters;
    using PlexModels.Media;

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
        /// <param name="start"></param>
        /// <param name="count"></param>
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
        /// <param name="start"></param>
        /// <param name="count"></param>
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
        /// <param name="start"></param>
        /// <param name="count"></param>
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
        /// <param name="start">Start Record</param>
        /// <param name="count">Count to return</param>
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
        /// <param name="start">Start Record</param>
        /// <param name="count">Count to return</param>
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
        /// <param name="start">Start Record</param>
        /// <param name="count">Count to return</param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchTracks(string title, string sort, List<FilterRequest> filters,
            int start = 0, int count = 100) =>
            await this.Search(true, title, sort, SearchType.Track, filters, start, count);
    }
}
