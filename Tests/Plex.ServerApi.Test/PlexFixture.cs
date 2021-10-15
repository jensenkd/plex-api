namespace Plex.ServerApi.Test
{
    using System;
    using System.Linq;
    using Api;
    using Clients;
    using Clients.Interfaces;
    using Library.ApiModels.Accounts;
    using Library.ApiModels.Servers;
    using Library.Factories;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Plex.Api.Factories;

    /// <summary>
    ///
    /// </summary>
    public class PlexFixture : IDisposable
    {
        public readonly ServiceProvider ServiceProvider;
        private readonly IConfiguration Configuration;

        public IPlexFactory PlexFactory { get; set; }
        public TestConfiguration TestConfiguration { get; set; }

        public PlexAccount PlexAccount { get; }
        public Server Server { get; }

        public PlexFixture()
        {
            this.Configuration = new ConfigurationBuilder()
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

            var services = new ServiceCollection();
            services.AddLogging(configure=> configure.AddConsole());
            services.AddSingleton(clientOptions);
            services.AddTransient<IPlexServerClient, PlexServerClient>();
            services.AddTransient<IPlexAccountClient, PlexAccountClient>();
            services.AddTransient<IPlexLibraryClient, PlexLibraryClient>();
            services.AddTransient<IApiService, ApiService>();
            services.AddTransient<IPlexFactory, PlexFactory>();
            services.AddTransient<IPlexRequestsHttpClient, PlexRequestsHttpClient>();

            this.ServiceProvider = services.BuildServiceProvider();

            this.TestConfiguration = new TestConfiguration(this.Configuration["Plex:Login"],
                this.Configuration["Plex:Password"], this.Configuration["Plex:AuthenticationKey"], clientOptions);

            this.PlexFactory = this.ServiceProvider.GetService<IPlexFactory>();
            if (this.PlexFactory == null)
            {
                throw new ApplicationException("Invalid Plex Factory Object");
            }

            this.PlexAccount = this.PlexFactory.GetPlexAccount(this.TestConfiguration.Login,
                this.TestConfiguration.Password);
            if (this.PlexAccount == null)
            {
                throw new ApplicationException("Invalid Login Credentials");
            }

            // Get First Owned Server
            var servers = this.PlexAccount.Servers().Result;
            this.Server = servers.First(c => c.Owned == 1);
            if (this.Server == null)
            {
                throw new ApplicationException("No Valid Server Found");
            }
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
        }
    }
}
