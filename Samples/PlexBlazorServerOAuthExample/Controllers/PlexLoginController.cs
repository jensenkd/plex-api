using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Plex.ServerApi.Clients.Interfaces;
using PlexBlazorServerOAuthExample.Services.Plex;
using System;
using System.Threading.Tasks;

namespace PlexBlazorServerOAuthExample.Controllers
{
    [Route("api/[controller]")]
    public class PlexLoginController : Controller
    {
        private readonly OAuthService _oAuthService;
        private readonly IPlexAccountClient _plexClient;

        public PlexLoginController(OAuthService oAuthService, IPlexAccountClient plexClient)
        {
            _oAuthService = oAuthService;
            _plexClient = plexClient;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var returnPath = Request.Scheme + "://" + Request.Host + Request.Path + "/PlexReturn";
            var oAuthUrl = await _plexClient.CreateOAuthPinAsync(returnPath);
            _oAuthService.OAuthID = oAuthUrl.Id;
            return Redirect(oAuthUrl.Url);
        }

        [HttpGet]
        [Route("PlexReturn")]
        public async Task<IActionResult> PlexReturn()
        {
            var oAuthId = _oAuthService.OAuthID.ToString();
            var oAuthPin = await _plexClient.GetAuthTokenFromOAuthPinAsync(oAuthId);

            if (string.IsNullOrEmpty(oAuthPin.AuthToken))
            {
                return Content(@"<h3 style=""text-align: center;"">Plex login failed, unable to obtain an authentication token.</h3>","text/html");
            }
            
            _oAuthService.PlexKey = oAuthPin.AuthToken;

            await _oAuthService.Login(oAuthPin.AuthToken);

            return Content(@"<script>window.close();</script>", "text/html");
        }
    }
}
