using System;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plex.Api.Helpers;
using Plex.Api.Models;

namespace Plex.Api.Tests
{
    public class TestBase
    {
        protected readonly ServiceProvider ServiceProvider;
        protected readonly IConfiguration Configuration;

        public string AuthenticationToken;

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

        public void SignIn()
        {
            var plexApi = ServiceProvider.GetService<IPlexClient>();

            var login = Configuration.GetValue<string>("Plex:Login");
            var password = Configuration.GetValue<string>("Plex:Password");

            PlexAuthentication auth = plexApi
                .SignIn(new UserRequest{ Login = login, Password = password}).Result;

            AuthenticationToken = auth.User.AuthenticationToken;
        }
    }
}