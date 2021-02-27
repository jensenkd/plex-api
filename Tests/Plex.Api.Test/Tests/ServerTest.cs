namespace Plex.Api.Test.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Factories;
    using Helpers;
    using Microsoft.Extensions.DependencyInjection;
    using Plex.Api;
    using Plex.Api.Test;
    using Xunit;

    public class ServerTest : TestBase
    {
        [Fact]
        public async Task Test_Plex_Server_InfoAsync()
        {
            var plexFactory = this.ServiceProvider.GetService<IPlexFactory>();

            // Get First Owned Server
            var servers = this.Account.GetAccountServersAsync().Result;
            var ownedServer = servers.First(c => c.Owned == 1);
            var fullUri = ownedServer.Host.ReturnUriFromServerInfo(ownedServer.Port, ownedServer.Scheme);

            var server = plexFactory.GetPlexServer(fullUri.ToString(), ownedServer.AccessToken);

            Assert.NotNull(server);
        }

        [Fact]
        public async Task Test_GetPlexServerLibrary()
        {
            var library = this.Server.GetLibrary();
            Assert.NotNull(library);
        }
    }
}
