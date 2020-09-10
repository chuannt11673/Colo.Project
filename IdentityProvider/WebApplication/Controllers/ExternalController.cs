using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Utilities;
using Core.Entities;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class ExternalController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IEventService _events;
        private readonly IService _service;

        public ExternalController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IEventService events,
            ServiceResolver serviceResolver)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _events = events;
            _signInManager = signInManager;
            _userManager = userManager;
            _service = serviceResolver("A");
        }

        [HttpPost]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Challenge(string provider, string returnUrl = null)
        {
            var callbackUrl = Url.Action("Callback", new { returnUrl });

            var props = new AuthenticationProperties
            {
                RedirectUri = callbackUrl,
                Items =
                {
                    { "scheme", provider },
                    { "returnUrl", returnUrl },
                    { "prompt", "select_account" }
                }
            };

            return Challenge(props, provider);
        }

        [HttpGet]
        public async Task<IActionResult> Callback(string returnUrl = null)
        {
            var result = await HttpContext.AuthenticateAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);
            if (result?.Succeeded != true)
            {
                throw new Exception("External authentication error");
            }

            // retrieve claims of the external user
            var externalUser = result.Principal;
            if (externalUser == null)
            {
                throw new Exception("External authentication error");
            }

            // retrieve claims of the external user
            var claims = externalUser.Claims.ToList();

            // try to determine the unique id of the external user - the most common claim type for that are the sub claim and the NameIdentifier
            // depending on the external provider, some other claim type might be used
            var userIdClaim = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);
            if (userIdClaim == null)
            {
                userIdClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            }
            if (userIdClaim == null)
            {
                throw new Exception("Unknown userid");
            }

            var userEmailClaim = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Email);
            if (userEmailClaim == null)
            {
                userEmailClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            }
            if (userEmailClaim == null)
            {
                throw new Exception("Unknown useremail");
            }

            var externalUserId = userIdClaim.Value;
            var externalProvider = userIdClaim.Issuer;

            var user = await _userManager.FindByLoginAsync(externalProvider, externalUserId);
            if (user == null)
            {
                user = new ApplicationUser() {
                    UserName = userEmailClaim.Value,
                    Email = userEmailClaim.Value,
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(user);
                await _userManager.AddLoginAsync(user, new UserLoginInfo(externalProvider, externalUserId, externalUserId));
            }

            await _signInManager.SignInAsync(user, new AuthenticationProperties());

            await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

            // validate return URL and redirect back to authorization endpoint or a local page
            if (_interaction.IsValidReturnUrl(returnUrl) || Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return Redirect("~/");
        }
    }
}