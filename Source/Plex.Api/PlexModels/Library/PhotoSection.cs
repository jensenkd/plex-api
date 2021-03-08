namespace Plex.Api.PlexModels.Library
{
    using ApiModels;
    using Media;

    public class PhotoSection : SectionBase
    {
        public MediaType MediaType { get; set; }


        //     class MusicSection(LibrarySection):
        // """ Represents a :class:`~plexapi.library.LibrarySection` section containing music artists.
        //     Attributes:
        //         TAG (str): 'Directory'
        //         TYPE (str): 'artist'
        // """
        // TAG = 'Directory'
        // TYPE = 'artist'
        //
        // CONTENT_TYPE = 'audio'
        // METADATA_TYPE = 'track'
        //
        // def albums(self):
        //     """ Returns a list of :class:`~plexapi.audio.Album` objects in this section. """
        //     key = '/library/sections/%s/albums' % self.key
        //     return self.fetchItems(key)
        //
        // def stations(self):
        //     """ Returns a list of :class:`~plexapi.audio.Album` objects in this section. """
        //     key = '/hubs/sections/%s?includeStations=1' % self.key
        //     return self.fetchItems(key, cls=Station)
        //
        // def searchArtists(self, **kwargs):
        //     """ Search for an artist. See :func:`~plexapi.library.LibrarySection.search` for usage. """
        //     return self.search(libtype='artist', **kwargs)
        //
        // def searchAlbums(self, **kwargs):
        //     """ Search for an album. See :func:`~plexapi.library.LibrarySection.search` for usage. """
        //     return self.search(libtype='album', **kwargs)
        //
        // def searchTracks(self, **kwargs):
        //     """ Search for a track. See :func:`~plexapi.library.LibrarySection.search` for usage. """
        //     return self.search(libtype='track', **kwargs)
        //
        // def sync(self, bitrate, limit=None, **kwargs):
        //     """ Add current Music library section as sync item for specified device.
        //         See description of :func:`~plexapi.library.LibrarySection.search` for details about filtering / sorting and
        //         :func:`~plexapi.library.LibrarySection.sync` for details on syncing libraries and possible exceptions.
        //         Parameters:
        //             bitrate (int): maximum bitrate for synchronized music, better use one of MUSIC_BITRATE_* values from the
        //                            module :mod:`~plexapi.sync`.
        //             limit (int): maximum count of tracks to sync, unlimited if `None`.
        //         Returns:
        //             :class:`~plexapi.sync.SyncItem`: an instance of created syncItem.
        //         Example:
        //             .. code-block:: python
        //                 from plexapi import myplex
        //                 from plexapi.sync import AUDIO_BITRATE_320_KBPS
        //                 c = myplex.MyPlexAccount()
        //                 target = c.device('Plex Client')
        //                 sync_items_wd = c.syncItems(target.clientIdentifier)
        //                 srv = c.resource('Server Name').connect()
        //                 section = srv.library.section('Music')
        //                 section.sync(AUDIO_BITRATE_320_KBPS, client=target, limit=100, sort='addedAt:desc',
        //                              title='New music')
        //     """
        //     from plexapi.sync import Policy, MediaSettings
        //     kwargs['mediaSettings'] = MediaSettings.createMusic(bitrate)
        //     kwargs['policy'] = Policy.create(limit)
        //     return super(MusicSection, self).sync(**kwargs)

    }
}
