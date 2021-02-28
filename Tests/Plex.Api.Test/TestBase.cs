namespace Plex.Api.Test
{
    using System;
    using System.Linq;
    using Account;
    using Clients;
    using Factories;
    using Helpers;
    using Plex.Api.Api;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit.Abstractions;
    using IPlexServerClient = Clients.IPlexServerClient;

    public class TestBase
    {
        protected readonly ServiceProvider ServiceProvider;
        protected readonly IConfiguration Configuration;
        protected readonly ClientOptions ClientOptions;

        public Account Account { get; }
        public Server Server { get; }

        protected TestBase()
        {
            this.Configuration = new ConfigurationBuilder()
                .AddUserSecrets<TestBase>()
                .Build();

            this.ClientOptions = new ClientOptions
            {
                Platform = "Web",
                Product = "API_UnitTests",
                DeviceName = "API_UnitTests",
                ClientId = "PlexApi",
                Version = "v1",
            };

            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton(this.ClientOptions);
            services.AddTransient<IPlexServerClient, PlexServerClient>();
            services.AddTransient<IPlexAccountClient, PlexAccountClient>();
            services.AddTransient<IPlexLibraryClient, PlexLibraryClient>();
            services.AddTransient<IApiService, ApiService>();
            services.AddTransient<IPlexFactory, PlexFactory>();
            services.AddTransient<IPlexRequestsHttpClient, PlexRequestsHttpClient>();

           this.ServiceProvider = services.BuildServiceProvider();

            var login = this.Configuration["Plex:Login"];
            var password = this.Configuration["Plex:Password"];

            var plexFactory = this.ServiceProvider.GetService<IPlexFactory>();
            if (plexFactory == null)
            {
                throw new ApplicationException("Invalid Plex Factory Object");
            }

            this.Account = plexFactory.GetPlexAccount(login, password);
            if (this.Account == null)
            {
                throw new ApplicationException("Invalid Login Credentials");
            }

            // Get First Owned Server
            var servers = this.Account.GetAccountServersAsync().Result;
            var ownedServer = servers.First(c => c.Owned == 1);
            var fullUri = ownedServer.Host.ReturnUriFromServerInfo(ownedServer.Port, ownedServer.Scheme);

            this.Server = plexFactory.GetPlexServer(fullUri.ToString(), ownedServer.AccessToken);
            if (this.Server == null)
            {
                throw new ApplicationException("No Valid Server Found");
            }
        }
    }
}
