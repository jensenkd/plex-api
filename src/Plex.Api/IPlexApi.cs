using System;
using System.Threading.Tasks;
using Plex.Api.Models;
using Plex.Api.Models.Friends;
using Plex.Api.Models.OAuth;
using Plex.Api.Models.Server;
using Plex.Api.Models.Status;


namespace Plex.Api
{
    public interface IPlexApi
    {
        Task<PlexStatus> GetStatus(string authToken, string uri);
        //Task<PlexLibrariesForMachineId> GetLibrariesForMachineId(string authToken, string machineId);
        Task<PlexAuthentication> SignIn(UserRequest user);
        Task<Models.Server.PlexServers> GetServers(string authToken);
        Task<LibrariesWrapper> GetLibrarySections(string authToken, string plexFullHost);
        Task<LibraryWrapper> GetLibrary(string authToken, string plexFullHost, string libraryId);
        Task<PlexMetadata> GetEpisodeMetaData(string authToken, string host, int ratingKey);
        Task<PlexMetadata> GetMetadata(string authToken, string plexFullHost, int itemId);
        Task<PlexMetadata> GetSeasons(string authToken, string plexFullHost, int ratingKey);
        Task<PlexContainer> GetAllEpisodes(string authToken, string host, string section, int start, int retCount);
        Task<PlexFriends> GetUsers(string authToken);
        Task<PlexAccount> GetAccount(string authToken);
        Task<PlexMetadata> GetRecentlyAdded(string authToken, string uri, string sectionId);
        Task<OAuthPin> GetPin(int pinId);
        Task<Uri> GetOAuthUrl(string code, string applicationUrl);
        Task<PlexAddWrapper> AddUser(string emailAddress, string serverId, string authToken, int[] libs);
    }
}