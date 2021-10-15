namespace Plex.Library.Test
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using ServerApi;
    using ServerApi.Api;
    using ServerApi.Clients;
    using ServerApi.Clients.Interfaces;

    public class PlexFixture
    {
        public PlexFixture()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets<PlexFixture>()
                .Build();

            var clientOptions = new ClientOptions
            {
                Platform = "Web",
                Product = "API_UnitTests",
                DeviceName = "API_UnitTests",
                ClientId = "PlexApi",
                Version = "v1",
            };

            var testConfiguration = new TestConfiguration(configuration["Plex:Host"],
                configuration["Plex:AuthenticationKey"],configuration["Plex:Login"],
                configuration["Plex:Password"]);

            var services = new ServiceCollection();
            services.AddLogging(configure=> configure.AddConsole());
            services.AddSingleton(testConfiguration);
            services.AddSingleton(clientOptions);
            services.AddTransient<IPlexServerClient, PlexServerClient>();
            services.AddTransient<IPlexAccountClient, PlexAccountClient>();
            services.AddTransient<IPlexLibraryClient, PlexLibraryClient>();
            services.AddTransient<IApiService, ApiService>();
            services.AddTransient<IPlexRequestsHttpClient, PlexRequestsHttpClient>();


            this.ServiceProvider = services.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; set; }
    }
}
