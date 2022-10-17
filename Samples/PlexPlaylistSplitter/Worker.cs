using Microsoft.Extensions.Options;
using Plex.Api.Factories;
using Plex.Library.ApiModels.Accounts;
using Plex.Library.ApiModels.Servers;
using Plex.ServerApi.Clients.Interfaces;
using Plex.ServerApi.PlexModels.Media;
using Plex.ServerApi.PlexModels.Server.Playlists;

namespace PlexPlaylistSplitter;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IHostApplicationLifetime _lifeTime;
    private readonly SplitOptions _splitOptions;
    private readonly IPlexFactory _plexFactory;
    private readonly IPlexServerClient _plexServerClient;
    private readonly IPlexLibraryClient _plexLibraryClient;

    public Worker(
        ILogger<Worker> logger,
        IHostApplicationLifetime lifetime,
        IOptions<SplitOptions> options,
        IPlexFactory plexFactory,
        IPlexServerClient plexServerClient,
        IPlexLibraryClient plexLibraryClient)
    {
        _logger = logger;
        _lifeTime = lifetime;
        _splitOptions = options.Value;
        _plexFactory = plexFactory;
        _plexServerClient = plexServerClient;
        _plexLibraryClient = plexLibraryClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogDebug("Worker running at: {StartTime}", DateTimeOffset.Now);

        if (string.IsNullOrEmpty(_splitOptions.PlexToken) &&
            (string.IsNullOrEmpty(_splitOptions.PlexUsername) || string.IsNullOrEmpty(_splitOptions.PlexPassword)))
        {
            _logger.LogError("Either PlexToken or PlexUsername and PlexPassword must be supplied");
            _lifeTime.StopApplication();
            return;
        }

        if (string.IsNullOrEmpty(_splitOptions.PlaylistName))
        {
            _logger.LogError("PlaylistName must be supplied");
            _lifeTime.StopApplication();
            return;
        }

        PlexAccount account = null!;
        if (!string.IsNullOrEmpty(_splitOptions.PlexToken))
        {
            account = _plexFactory.GetPlexAccount(_splitOptions.PlexToken);
        }
        else
        {
            account = _plexFactory.GetPlexAccount(_splitOptions.PlexUsername, _splitOptions.PlexPassword);
        }

        _logger.LogDebug("Successfully retrieved account {PlexAccountUuid}", account.Uuid);

        var serverSummaries = await account.ServerSummaries();
        var myServerSummary = serverSummaries.Servers
            .FirstOrDefault(x => string.IsNullOrEmpty(_splitOptions.PlexServerName) ? x.Owned == 1 : x.Name == _splitOptions.PlexServerName);

        if (myServerSummary == null)
        {
            _logger.LogError("No matching server found");
            _lifeTime.StopApplication();
            return;
        }

        myServerSummary.Host = _splitOptions.ServerHostOverride ?? myServerSummary.Host;
        myServerSummary.Port = _splitOptions.ServerPortOverride ?? myServerSummary.Port;

        var myServer = new Server(_plexServerClient, _plexLibraryClient, myServerSummary);

        var playlists = await myServer.Playlists();

        var sourceName = _splitOptions.PlaylistName;
        var splitSize = _splitOptions.SplitCount;

        var sourcePlaylist = playlists.Metadata.Single(x => x.Title == sourceName);

        var sourceItems = await myServer.GetPlaylistItems(sourcePlaylist);

        var metadata = sourceItems.Media;
        if (_splitOptions.SortPlaylist)
        {
            metadata = metadata.OrderBy(item => item.Media[0].Part[0].File).ToList();
        }

        var processedSplits = 0;
        var accumulatedMetadata = new List<Metadata>();

        var totalSplits = (int)Math.Ceiling(metadata.Count / (double)splitSize);

        foreach (var item in metadata)
        {
            if (accumulatedMetadata.Count == splitSize)
            {
                processedSplits++;
                await CreatePlaylistAsync(myServer, sourceName, processedSplits, totalSplits, accumulatedMetadata, stoppingToken);
                accumulatedMetadata.Clear();
            }
            accumulatedMetadata.Add(item);
        }

        if (accumulatedMetadata.Count != 0)
        {
            processedSplits++;
            await CreatePlaylistAsync(myServer, sourceName, processedSplits, totalSplits, accumulatedMetadata, stoppingToken);
            accumulatedMetadata.Clear();
        }

        _logger.LogInformation("Created {TotalSplits} playlists for {ItemCount} items", totalSplits, metadata.Count);
        _lifeTime.StopApplication();
    }

    private async Task CreatePlaylistAsync(Server myServer, string sourceName, int processedSplits, int totalSplits, List<Metadata> accumulatedMetadata, CancellationToken stoppingToken)
    {
        var chunkSize = _splitOptions.ChunkSize;
        var playlistType = _splitOptions.PlaylistType;

        var chunks = accumulatedMetadata.Select(x => x.RatingKey).Chunk(chunkSize);
        PlaylistMetadata? metadata = null;
        foreach (var chunk in chunks)
        {
            if (metadata == null)
            {
                var playlistContainer = await myServer.CreatePlaylist($"{sourceName} Split {processedSplits} of {totalSplits}", playlistType, chunk);
                metadata = playlistContainer.Metadata.First();
            }
            else
            {
                await myServer.AddPlaylistItems(metadata, chunk);
            }
        }
    }
}
