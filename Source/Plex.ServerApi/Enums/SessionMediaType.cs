namespace Plex.ServerApi.Enums
{
    /// <summary>
    /// Session Media Type Object
    /// {'movie': 1, 'show': 2, 'season': 3, 'episode': 4, 'trailer': 5, 'comic': 6, 'person': 7,
    /// 'artist': 8, 'album': 9, 'track': 10, 'picture': 11, 'clip': 12, 'photo': 13, 'photoalbum': 14,
    /// 'playlist': 15, 'playlistFolder': 16, 'collection': 18, 'optimizedVersion': 42, 'userPlaylistItem': 1001}
    /// </summary>
    public enum SessionMediaType
    {
        /// <summary>
        /// Movie
        /// </summary>
        Movie = 1,

        /// <summary>
        /// TV Show
        /// </summary>
        Show = 2,

        /// <summary>
        /// TV Season
        /// </summary>
        Season = 3,

        /// <summary>
        /// TV Episode
        /// </summary>
        Episode = 4,

        /// <summary>
        /// Movie Trailer
        /// </summary>
        Trailer = 5,

        /// <summary>
        /// Comic
        /// </summary>
        Comic = 6,

        /// <summary>
        /// Person
        /// </summary>
        Person = 7,

        /// <summary>
        /// Artist
        /// </summary>
        Artist = 8,

        /// <summary>
        /// Music Album
        /// </summary>
        Album = 9,

        /// <summary>
        /// Music Track
        /// </summary>
        Track = 10,

        /// <summary>
        /// Photo Album
        /// </summary>
        PhotoAlbum = 14,

        /// <summary>
        /// Picture
        /// </summary>
        Picture = 11,

        /// <summary>
        /// Photo
        /// </summary>
        Photo = 13,

        /// <summary>
        /// Clip
        /// </summary>
        Clip = 12,

        /// <summary>
        /// Playlist Item
        /// </summary>
        PlayListItem = 15,

        /// <summary>
        /// Playlist Folder
        /// </summary>
        PlayListFolder = 16,

        /// <summary>
        /// Collection Item
        /// </summary>
        Collection = 18
    }
}
