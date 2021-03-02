namespace Plex.Api.Test
{
    using System;
    using System.Linq;
    using Api;
    using ApiModels;
    using Clients;
    using Factories;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class PlexFixture : IDisposable
    {
        public readonly ServiceProvider ServiceProvider;
        public readonly IConfiguration Configuration;

        public IPlexFactory PlexFactory { get; set; }
        public TestConfiguration TestConfiguration { get; set; }

        public Account Account { get; }
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
            services.AddLogging();
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

            this.Account = this.PlexFactory.GetPlexAccount(this.TestConfiguration.Login, this.TestConfiguration.Password);
            if (this.Account == null)
            {
                throw new ApplicationException("Invalid Login Credentials");
            }

            // Get First Owned Server
            var servers = this.Account.Servers().Result;
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
