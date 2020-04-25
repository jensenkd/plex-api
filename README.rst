plex-api
==============

.. image:: https://github.com/jensenkd/plex-api/workflows/.NET%20Core/badge.svg
    :target: https://github.com/jensenkd/plex-api

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
.. code-block:: C#
    Nuget-Install 'Plex.Api'

Dotnet Cli
.. code-block:: C#
    dotnet add package 'Plex.Api'


Documentation_ can be found at Read the Docs.

.. _Documentation: http://jensenkd-plex-api.readthedocs.io/en/latest/

Getting a PlexClient Instance
-----------------------------

There are two types of authentication. If you are running on a separate network
or using Plex Users you can log into MyPlex to get a PlexServer instance. An
example of this is below. NOTE: Servername below is the name of the server (not
the hostname and port).  If logged into Plex Web you can see the server name in
the top left above your available libraries.

.. code-block:: C#

    // Create Client Options
    var apiOptions = new ClientOptions
    {
        ApplicationName = "API_UnitTests",
        DeviceName = "API_UnitTests",
        ClientId = Guid.NewGuid()
    };

    // Create DI Provider
    var services = new ServiceCollection();
    services.AddLogging();
    services.AddSingleton(apiOptions);
    services.AddTransient<IPlexClient, PlexClient>();
    services.AddTransient<IApiService, ApiService>();
    services.AddTransient<IPlexRequestsHttpClient, PlexRequestsHttpClient>();
    ServiceProvider = services.BuildServiceProvider();
    

If you want to avoid logging into MyPlex and you already know your auth token
string, you can use the PlexServer object directly as above, but passing in
the baseurl and auth token directly.

.. code-block:: C#

    var plexApi = ServiceProvider.GetService<IPlexClient>();
    
    User user = plexApi
        .SignIn(login, password).Result;


Collections

.. code-block:: C#

    var plexApi = ServiceProvider.GetService<IPlexClient>();
    
    // Get Collections for Library
    var collections = plexApi
        .GetCollections(authKey, plexServerUrl, libraryKey).Result;
        
    // Get Collection Tags for Movie
    var collectionTags = plexApi.GetCollectionTagsForMovie(authKey, plexServerUrl, movieKey).Result;
        
    // Get Collection
    var collection = plexApi.GetCollection(authKey, plexServerUrl, collectionKey).Result;    
    
    // Get Collection Movies
    var movies = plexApi.GetCollectionMovies(authKey, plexServerUrl, collectionKey).Result;

    // Delete Collection from Movie
    plexApi.DeleteCollectionFromMovie(authKey, plexServerUrl, libraryKey, movieKey, collectionName);
    
    // Add Collection to Movie
    plexApi.AddCollectionToMovie(authKey, plexServerUrl, libraryKey, movieKey, collectionName);

    // Update Collection
    var collection = plexApi.GetCollection(authKey, fullUri, collectionRatingKey).Result;
    collection.Title = "New Title for Collection";
    plexApi.UpdateCollection(authKey, plexServerUrl, libraryKey, collection);
            

