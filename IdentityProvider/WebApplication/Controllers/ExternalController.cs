using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Utilities;
using Core.Entities;
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
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action("Callback", "External", new { ReturnUrl = returnUrl ?? Url.Action("Index", "Home") });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }

        [HttpGet]
        public async Task<IActionResult> Callback(string returnUrl = null)
        {
            // lookup our user and external provider info
            var (user, provider, providerUserId) = await FindUserFromExternalProvider();


            await _signInManager.SignInAsync(user, isPersistent: false);
            // delete temporary cookie used during external authentication
            await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);

            // check if external login is in the context of an OIDC request
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            await _events.RaiseAsync(new UserLoginSuccessEvent(provider, providerUserId, user.Id, user.UserName, true, context?.ClientId));

            if (context != null)
            {
                if (await _clientStore.IsPkceClientAsync(context.ClientId))
                {
                    // if the client is PKCE then we assume it's native, so this change in how to
                    // return the response is for better UX for the end user.
                    return this.LoadingPage("Redirect", returnUrl);
                }
            }

            return Redirect(returnUrl);
        }

        private async Task<Tuple<ApplicationUser, string, string>> FindUserFromExternalProvider()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
                throw new Exception("External login failed!");

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email
                };

                await _userManager.CreateAsync(user);
                await _userManager.AddLoginAsync(user, info);
            }

            return new Tuple<ApplicationUser, string, string>(user, info.LoginProvider, info.ProviderKey);
        }
    }
}