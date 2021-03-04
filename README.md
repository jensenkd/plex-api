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

Getting a PlexClient Instance
-----------------------------

There are two types of authentication. If you are running on a separate network
or using Plex Users you can log into PlexAccount to get a PlexAccount instance. An
example of this is below. NOTE: Servername below is the name of the server (not
the hostname and port).  If logged into Plex Web you can see the server name in
the top left above your available libraries.

NOTE: v2.0 documentation updates are incoming...

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

If you want to avoid logging into MyPlex and you already know your auth token
string, you can use the PlexServer object directly as above, but passing in
the baseurl and auth token directly.

Server

```c#

    var plexFactory = this.ServiceProvider.GetService<IPlexFactory>();
    
    // First, you will need to create a PlexAccount object.
    
    // Signin with Username, Password
    PlexAccount account = plexFactory
        .GetPlexAccount("username", "password");
    
    // or use and Plex Auth token
    var account = plexFactory
        .GetPlexAccount("access_token_here");
    
    // Get Plex Announcements
    var announcements = account.Announcements().Result;
     
    // Get Server Summaries
    var servers = account.ServerSummaries().Result;
         
    // Get Servers (Active Servers w/Details)
    var servers = account.Servers().Result;
    
    // Get Friends
    var friends = account.Friends().Result;
    
    // Get Resources
    var resources = account.Resources().Result;
    
    // Get Providers
    var providers = account.Providers().Result;
    
```

Libraries

```c#

    var servers = account.Servers().Result;
    
    // Get First owned server
    var myServer = servers.Where(c=>c.Owned == "1").First();
    
    // Get Libraries
    var libraries = myServer.Libraries().Result;
    
     // Get Movies library
    var movieLibrary = libraries.Single(c => c.Title == "Movies");
  
    // Get Recently Added for Library
    var recentlyAdded = movieLibrary.RecentlyAdded().Result;

```

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
