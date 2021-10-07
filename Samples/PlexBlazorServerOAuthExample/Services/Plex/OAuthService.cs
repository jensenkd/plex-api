using System;
using System.Threading.Tasks;

namespace PlexBlazorServerOAuthExample.Services.Plex
{
    public class OAuthService
    {
        public int OAuthID { get; set; }
        public string PlexKey { get; set; }
        public static event Func<string, Task> LoginEvent;

        public async Task Login(string PlexKey)
        {
            await (LoginEvent?.Invoke(PlexKey) ?? Task.CompletedTask);
        }

    }
}
