using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Auth.WebApp.IdentityServer4
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "ionic",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                AllowOfflineAccess = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                RedirectUris = new List<string> { "https://ionic-hats.com/auth-callback", "http://localhost:8100/auth-callback" },
                PostLogoutRedirectUris = new List<string> { "https://ionic-hats.com/", "http://localhost:8100/" },
                FrontChannelLogoutUri = "http://localhost:8100/",
                AllowAccessTokensViaBrowser = true
            }
        };
    }
}
