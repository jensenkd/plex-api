plex-api
==============

[![.NET](https://github.com/jensenkd/plex-api/actions/workflows/dotnet.yml/badge.svg)](https://github.com/jensenkd/plex-api/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/jensenkd/plex-api/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/jensenkd/plex-api/actions/workflows/codeql-analysis.yml)
[![Nuget Pre-Release](https://github.com/jensenkd/plex-api/actions/workflows/pre-release.yml/badge.svg)](https://github.com/jensenkd/plex-api/actions/workflows/pre-release.yml)
[![Nuget Release](https://github.com/jensenkd/plex-api/actions/workflows/release.yml/badge.svg)](https://github.com/jensenkd/plex-api/actions/workflows/release.yml)
[![NuGet version (Newtonsoft.Json)](https://img.shields.io/nuget/v/Plex.Api.svg?style=flat-square)](https://www.nuget.org/packages/Plex.Api/)


Overview
--------
Unofficial c# bindings for the Plex Media Server API. Our goal is to match all capabilities of the official
Plex Web Client. A few of the many features we currently support are:

* Navigate local or remote shared libraries.
* Perform library actions such as scan, analyze, empty trash.
* Remote control and play media on connected clients.
* Listen in on all Plex Server notifications.


Installation & Documentation
----------------------------

From Powershell
```c#
    Nuget-Install 'Plex.Api'
```

Dotnet Cli
```c#
    dotnet add package 'Plex.Api'
```

Getting a PlexAccount Instance
-----------------------------

NOTE: v2.0 documentation updates are incoming...

Boiler plate dependency injection setup.

```c#
    // Create Client Options
    var apiOptions = new ClientOptions
    {
        Product = "API_UnitTests",
        DeviceName = "API_UnitTests",
        ClientId = "MyClientId",
        Platform = "Web",
        Version = "v1"
    };

    // Setup Dependency Injection
    var services = new ServiceCollection();
    services.AddSingleton(apiOptions);
    services.AddTransient<IPlexServerClient, PlexServerClient>();
    services.AddTransient<IPlexAccountClient, PlexAccountClient>();
    services.AddTransient<IPlexLibraryClient, PlexLibraryClient>();
    services.AddTransient<IApiService, ApiService>();
    services.AddTransient<IPlexFactory, PlexFactory>();
    services.AddTransient<IPlexRequestsHttpClient, PlexRequestsHttpClient>();
    
    this.ServiceProvider = services.BuildServiceProvider();
```    

The entry point to Plex-Api is with the PlexAccount class.  You can instantiate a PlexAccount class using either your <br />
Plex account login and password, or your Plex authtoken.

```c#
    var plexFactory = this.ServiceProvider.GetService<IPlexFactory>();
    
    // First, you will need to create a PlexAccount object.
    
    // Signin with Username, Password
    PlexAccount account = plexFactory
        .GetPlexAccount("username", "password");
    
    // or use and Plex Auth token
    var account = plexFactory
        .GetPlexAccount("access_token_here");

```

PlexAccount Documentation
-----------------------------
```c#
    // Get Announcements for Plex Account
    var announcements = account.Announcements().Result;
     
    // Get Server Summaries.  This does not return a Server Instance but a summary
    // of all servers tied to your Plex Account.  The servers may not be active/online.
    var servers = account.ServerSummaries().Result;
         
    // Get Servers (Active Servers w/Details)
    var servers = account.Servers().Result;
    
    // Get list of Friends for Plex Account
    var friends = account.Friends().Result;
    
    // Get Resources
    var resources = account.Resources().Result;
    
    // Get Providers
    var providers = account.Providers().Result;
    
    // Returns a list of all User objects connected to your account.
    // This includes both friends and pending invites. You can reference the user.Friend to
    // distinguish between the two.
    var users = account.users().Result;
    
    // Opt in or out of sharing stuff with plex.
    // See: https://www.plex.tv/about/privacy-legal/
    bool optOutOfPlaybackDetails = true;
    bool optOutOfLibraryDetails = true;
    account.OptOut(optOutOfPlaybackDetails, optOutOfLibraryDetails);
 
    // Get Account Devices
    var devices = account.Devices().Result;      
```

Server Documentation
-----------------------------
```c#
    var servers = account.Servers().Result;
    var myServer = servers.Where(c=>c.Owned == "1").First();
    
    // Get Home OnDeck items
    var onDeckItems = myServer.HomeOnDeck().Result;
    
    // Get Recently Added items for the Home Hub
    var recentItems = myServer.HomeHubRecentlyAdded().Result;
    
    // Get Continue Watching items for the Home Hub
    var continueItems = myServer.HomeHubContinueWatching().Result;
    
    // Share library content with the specified user.
    string sections = "1,3,4";
    myServer.InviteFriend("testuser", sections); 
    
    // Get Providers for this Server
    var providers = myServer.Providers().Result;
    
    // Search Across All Hubs on this Server
    var items = myServer.HubLibrarySearch("Harry Potter").Result;
    
    // Get Play History for all library sections on this server.
    var playHistory = myServer.PlayHistory().Result;
    
    // Get Devices connected to this Server
    var devices = myServer.Devices().Result;
    
    // Get list of all Client objects connected to server.
    var clients = myServer.Clients().Result;
    
    // Scrobble Item on this server
    myServer.ScrobbleItem("123");

    // UnScrobble Item on this server
    myServer.UnScrobbleItem("123");

    // Downloads Server Logs
    var logs = myServer.DownloadLogs().Result;
    
    // Get list of all release updates available for this Server
    var updates = myServer.CheckForUpdate().Result;
    
    // Get Server Activities.
    var activities = myServer.Activities().Result;

    // Get Server Statistics.
    var statistics = myServer.Activities().Result;
    
    // Force Plex Server to download new SyncList from Plex.tv.
    myServer.RefreshSyncList();
    
    // Force Plex Server to refresh content for known SyncLists.
    myServer.RefreshContent();
    
    // Force Plex Server to download new SyncList and refresh content.
    myServer.RefreshSync();
    
    // Get Transcode Sessions
    var transcodeSessions = myServer.TranscodeSessions().Result;
    
    // Get Server active Sessions
    var sessions = myServer.Sessions().Result;
    
    // Get Server Playlists
    var playlists = myServer.Playlists().Result;

```

Library Documentation
-----------------------------

```c#
    var servers = account.Servers().Result;
    var myServer = servers.Where(c=>c.Owned == "1").First();
     
    // Get Libraries for server
    var libraries = myServer.Libraries().Result;
    
     // Get Movies library
    var movieLibrary = libraries.Single(c => c.Title == "Movies");
  
    // Get Search Filters available for this Library
    var filters = movieLibrary.SearchFilters().Result;
  
    // Search Library for item
    string title = "Harry Potter";
    string sort = "rating:desc";
    string libraryType = "movie";
    var items = movieLibrary.Search(title, sort, libraryType).Result;
 
    // Get Recently Added for Library
    var recentlyAdded = movieLibrary.RecentlyAdded().Result;
    
    // Return list of Hubs on this library along with their Metadata items
    var hubs = movieLibrary.Hubs();
    
    // Empty Trash for this Library
    movieLibrary.EmptyTrash();
    
    // Scan for new items on this Library
    movieLibrary.ScanForNewItems();
    
    // Cancel running Scan on this library
    movieLibrary.CancelScan();

```


#OLD DOCUMENTATION (NEED TO UPDATE)

Metadata

```c#

    var plexApi = ServiceProvider.GetService<IPlexClient>();
         
    // Get Metadata for Library
    var metadatas = plexApi.MetadataForLibraryAsync(string authToken, string plexServerHost, string libraryKey).Result;
  
    // Get Children for Metadata by Metadata Key
    var metadatas = plexApi.GetChildrenMetadataAsync(string authToken, string plexServerHost, int metadataKey).Result;

    // Get Metadata by Key
    var metadata = plexApi.GetMetadataAsync(string authToken, string plexServerHost, int metadataKey).Result;

    // Search
    var metadatas = plexApi.SearchAsync(string authToken, string plexServerHost, string query).Result;   
```

Sessions

```c#

    var plexApi = ServiceProvider.GetService<IPlexClient>();
    
    // Get All Sessions on Server
    var sessions = plexApi.GetSessionsAsync(string authToken, string plexServerHost).Result;
    
    // Get Session for Player Machine Id
    var session = plexApl.GetSessionByPlayerIdAsync(string authToken, string plexServerHost, string playerKey).Result;
```


Collections

```c#

    var plexApi = ServiceProvider.GetService<IPlexClient>();
    
    // Get Collections for Library
    var collections = plexApi
        .GetCollections(authKey, plexServerUrl, libraryKey).Result;
        
    // Get Collection Tags for Movie
    var collectionTags = plexApi.GetCollectionTagsForMovieAsync(authKey, plexServerUrl, movieKey).Result;
        
    // Get Collection
    var collection = plexApi.GetCollectionAsync(authKey, plexServerUrl, collectionKey).Result;    
    
    // Get Collection Movies
    var movies = plexApi.GetCollectionMoviesAsync(authKey, plexServerUrl, collectionKey).Result;

    // Delete Collection from Movie
    plexApi.DeleteCollectionFromMovieAsync(authKey, plexServerUrl, libraryKey, movieKey, collectionName);
    
    // Add Collection to Movie
    plexApi.AddCollectionToMovieAsync(authKey, plexServerUrl, libraryKey, movieKey, collectionName);

    // Update Collection
    var collection = plexApi.GetCollectionAsync(authKey, fullUri, collectionRatingKey).Result;
    collection.Title = "New Title for Collection";
    plexApi.UpdateCollection(authKey, plexServerUrl, libraryKey, collection);

```

OAuth Implementation Example

```c#

    public class PlexLoginController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly PlexOAuthClient _plexOAuthClient;
        private readonly IPlexClient _plexClient;

        public PlexLoginController(PlexOAuthClient plexOAuthClient, IPlexClient plexClient)
        {
            _plexOAuthClient = plexOAuthClient;
            _plexClient = plexClient;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var redirectUrl = Url.Action("PlexReturn", "PlexLogin", null, Request.Scheme);
            var oauthUrl = await _plexClient.CreateOAuthPinAsync(redirectUrl);
            HttpContext.Session.SetString("PlexOauthId", oauthUrl.Id.ToString());
            return Redirect(oauthUrl.Url);
        }

        public async Task<IActionResult> PlexReturn()
        {
            var oauthId = HttpContext.Session.GetString("PlexOauthId");
            var oAuthPin = await _plexClient.GetAuthTokenFromOAuthPinAsync(oauthId);

            if (string.IsNullOrEmpty(oAuthPin.AuthToken))
                throw new Exception("Plex auth failed.");
            HttpContext.Session.Remove("PlexOauthId");
            HttpContext.Session.SetString("PlexKey", oAuthPin.AuthToken);

            return Redirect("/plex");
        }
    }
```
