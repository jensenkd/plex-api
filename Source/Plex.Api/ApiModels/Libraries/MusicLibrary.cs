namespace Plex.Api.ApiModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Clients.Interfaces;
    using Enums;
    using Libraries;
    using PlexModels.Media;

    /// <summary>
    /// def albums(self):
    /// """ Returns a list of :class:`~plexapi.audio.Album` objects in this section. """
    /// key = '/library/sections/%s/albums' % self.key
    /// return self.fetchItems(key)
    ///
    /// def stations(self):
    /// """ Returns a list of :class:`~plexapi.audio.Album` objects in this section. """
    /// key = '/hubs/sections/%s?includeStations=1' % self.key
    /// return self.fetchItems(key, cls=Station)
    ///
    /// def searchArtists(self, **kwargs):
    /// """ Search for an artist. See :func:`~plexapi.library.LibrarySection.search` for usage. """
    /// return self.search(libtype='artist', **kwargs)
    ///
    /// def searchAlbums(self, **kwargs):
    /// """ Search for an album. See :func:`~plexapi.library.LibrarySection.search` for usage. """
    /// return self.search(libtype='album', **kwargs)
    ///
    /// def searchTracks(self, **kwargs):
    /// """ Search for a track. See :func:`~plexapi.library.LibrarySection.search` for usage. """
    /// return self.search(libtype='track', **kwargs)
    ///
    /// def sync(self, bitrate, limit=None, **kwargs):
    /// """ Add current Music library section as sync item f
    /// </summary>
    public class MusicLibrary : LibraryBase
    {
        public MusicLibrary(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
            : base(plexServerClient, plexLibraryClient, server)
        {
        }

        public async Task<MediaContainer> Albums(string sort, int start = 0, int count = 100)
        {
            //'/library/sections/{this.Key}/albums'
            throw new NotImplementedException();
        }

        public async Task<MediaContainer> Stations(string sort, int start = 0, int count = 100)
        {
            //'/hubs/sections/{this.Key}?includeStations=1'
            throw new NotImplementedException();
        }

        public async Task<MediaContainer> SearchArtists(string name, string sort, Dictionary<string, string> filters,
            int start = 0, int count = 100) =>
            await this.Search(true, name, sort, SearchType.Artist, filters, start, count);

        public async Task<MediaContainer> SearchAlbums(string title, string sort, Dictionary<string, string> filters,
            int start = 0, int count = 100) =>
            await this.Search(true, title, sort, SearchType.Artist, filters, start, count);

        public async Task<MediaContainer> SearchTracks(string title, string sort, Dictionary<string, string> filters,
            int start = 0, int count = 100) =>
            await this.Search(true, title, sort, SearchType.Track, filters, start, count);
    }
}
