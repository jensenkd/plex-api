# Plex Media Server SDK
.NET Core SDK for Plex Media Server

.. image:: https://github.com/jensenkd/plex-api/workflows/.NET%20Core/badge.svg
    :target: https://github.com/jensenkd/plex-api

Overview
--------
Unofficial Python bindings for the Plex API. Our goal is to match all capabilities of the official
Plex Web Client. A few of the many features we currently support are:

* Navigate local or remote shared libraries.
* Perform library actions such as scan, analyze, empty trash.
* Remote control and play media on connected clients.
* Listen in on all Plex Server notifications.


Installation & Documentation
----------------------------

.. code-block:: python

    pip install plexapi

Documentation_ can be found at Read the Docs.

.. _Documentation: http://python-plexapi.readthedocs.io/en/latest/

Getting a PlexClient Instance
-----------------------------

There are two types of authentication. If you are running on a separate network
or using Plex Users you can log into MyPlex to get a PlexServer instance. An
example of this is below. NOTE: Servername below is the name of the server (not
the hostname and port).  If logged into Plex Web you can see the server name in
the top left above your available libraries.

.. code-block:: python

    from plexapi.myplex import MyPlexAccount
    account = MyPlexAccount('<USERNAME>', '<PASSWORD>')
    plex = account.resource('<SERVERNAME>').connect()  # returns a PlexServer instance

If you want to avoid logging into MyPlex and you already know your auth token
string, you can use the PlexServer object directly as above, but passing in
the baseurl and auth token directly.

.. code-block:: python

    from plexapi.server import PlexServer
    baseurl = 'http://plexserver:32400'
    token = '2ffLuB84dqLswk9skLos'
    plex = PlexServer(baseurl, token)
    
    
 Usage Examples
--------------

.. code-block:: python

    # Example 1: List all unwatched movies.
    movies = plex.library.section('Movies')
    for video in movies.search(unwatched=True):
        print(video.title)


.. code-block:: python

    # Example 2: Mark all Game of Thrones episodes watched.
    plex.library.section('TV Shows').get('Game of Thrones').markWatched()


.. code-block:: python

    # Example 3: List all clients connected to the Server.
    for client in plex.clients():
        print(client.title)


.. code-block:: python

    # Example 4: Play the movie Cars on another client.
    # Note: Client must be on same network as server.
    cars = plex.library.section('Movies').get('Cars')
    client = plex.client("Michael's iPhone")
    client.playMedia(cars)


.. code-block:: python

    # Example 5: List all content with the word 'Game' in the title.
    for video in plex.search('Game'):
        print('%s (%s)' % (video.title, video.TYPE))


.. code-block:: python

    # Example 6: List all movies directed by the same person as Elephants Dream.
    movies = plex.library.section('Movies')
    die_hard = movies.get('Elephants Dream')
    director = die_hard.directors[0]
    for movie in movies.search(None, director=director):
        print(movie.title)


.. code-block:: python

    # Example 7: List files for the latest episode of The 100.
    last_episode = plex.library.section('TV Shows').get('The 100').episodes()[-1]
    for part in last_episode.iterParts():
        print(part.file)


.. code-block:: python

    # Example 8: Get audio/video/all playlists
    for playlist in plex.playlists():
        print(playlist.title)


.. code-block:: python

    # Example 9: Rate the 100 four stars.
    plex.library.section('TV Shows').get('The 100').rate(8.0)
