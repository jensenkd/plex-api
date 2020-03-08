using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plex.Api.Helpers;

namespace Plex.Api.Tests
{
    public class TestBase
    {
        protected readonly ServiceProvider ServiceProvider;
        protected readonly IConfiguration Configuration;

        protected TestBase()
        {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<TestBase>()
                .Build();
            
            var apiOptions = new ClientOptions
            {
                ApplicationName = "API_UnitTests",
                DeviceName = "API_UnitTests",
                ClientId = Guid.NewGuid()
            };
            
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton(apiOptions);
            services.AddSingleton<IApi, Helpers.Api>();
            services.AddSingleton<IGenericHttpClient, GenericHttpClient>();
            services.AddTransient<IPlexClient, PlexClient>();
            
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}