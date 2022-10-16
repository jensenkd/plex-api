using Plex.Api.Factories;
using Plex.Library.Factories;
using Plex.ServerApi;
using Plex.ServerApi.Api;
using Plex.ServerApi.Clients;
using Plex.ServerApi.Clients.Interfaces;
using PlexPlaylistSplitter;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
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
        services.AddSingleton(apiOptions);
        services.AddTransient<IPlexServerClient, PlexServerClient>();
        services.AddTransient<IPlexAccountClient, PlexAccountClient>();
        services.AddTransient<IPlexLibraryClient, PlexLibraryClient>();
        services.AddTransient<IApiService, ApiService>();
        services.AddTransient<IPlexFactory, PlexFactory>();
        services.AddTransient<IPlexRequestsHttpClient, PlexRequestsHttpClient>();
        services.Configure<SplitOptions>(hostContext.Configuration);


    })
    .Build();

await host.RunAsync();
