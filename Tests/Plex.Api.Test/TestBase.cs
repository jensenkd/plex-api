namespace Plex.Api.Test
{
    using Plex.Api.Api;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class TestBase
    {
        protected readonly ServiceProvider ServiceProvider;
        protected readonly IConfiguration Configuration;

        protected readonly ClientOptions ClientOptions;

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
            services.AddTransient<IPlexClient, PlexClient>();
            services.AddTransient<IApiService, ApiService>();
            services.AddTransient<IPlexRequestsHttpClient, PlexRequestsHttpClient>();

            this.ServiceProvider = services.BuildServiceProvider();
        }
    }
}
