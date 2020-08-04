using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Application.IdentityServer4
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource> {
            new ApiResource("colo.netcore.api", "colo api")
        };

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "ionic-native",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedGrantTypes = GrantTypes.Code,
                RequireConsent = false,
                RequirePkce = true,
                AllowOfflineAccess = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "colo.netcore.api"
                },
                RedirectUris = new List<string> { "https://ionic-hats.com/auth-callback", "http://localhost:8100/auth-callback" },
                PostLogoutRedirectUris = new List<string> { "https://ionic-hats.com/", "http://localhost:8100/" },
                FrontChannelLogoutUri = "http://localhost:8100/",
                AllowAccessTokensViaBrowser = true
            },
            new Client
            {
                ClientId = "ionic-angular",
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedGrantTypes = GrantTypes.Implicit,
                RequireConsent = false,
                AllowOfflineAccess = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "colo.netcore.api"
                },
                RedirectUris = new List<string> { "http://localhost:8100/auth-callback" },
                PostLogoutRedirectUris = new List<string> { "http://localhost:8100/" },
                FrontChannelLogoutUri = "http://localhost:8100/",
                AllowAccessTokensViaBrowser = true
            }
        };
    }
}
