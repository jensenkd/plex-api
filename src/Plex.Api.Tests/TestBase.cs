using System;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plex.Api.Api;
using Plex.Api.Helpers;
using Plex.Api.Models;

namespace Plex.Api.Tests
{
    public class TestBase
    {
        protected readonly ServiceProvider ServiceProvider;
        protected readonly IConfiguration Configuration;

        protected readonly ClientOptions ClientOptions;
        
        protected TestBase()
        {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<TestBase>()
                .Build();
            
            ClientOptions = new ClientOptions
            {
                Platform = "Web",
                Product = "API_UnitTests",
                DeviceName = "API_UnitTests",
                ClientId = "PlexApi",
                Version = "v1"
            };
            
            
            
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton(ClientOptions);
            services.AddTransient<IPlexClient, PlexClient>();
            services.AddTransient<IApiService, ApiService>();
            services.AddTransient<IPlexRequestsHttpClient, PlexRequestsHttpClient>();
            
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}