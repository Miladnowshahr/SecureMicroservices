using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

public class Config
{
    public static IEnumerable<Client> Clients => new Client[] {
        new Client
        {
            ClientId="movieClient",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            AllowedScopes={"movieAPI"},
        },
        new Client
        {
            ClientId="movies_mvc_client",
            ClientName="Movies",
            AllowedGrantTypes=GrantTypes.Code,
            AllowRememberConsent=false,
            RedirectUris=new List<string>(){"http://localhost:5002/signin-oidc"},
            PostLogoutRedirectUris= new List<string>{"http://localhost:5002/signout-callback-oidc"},
            ClientSecrets=new List<Secret>{new Secret("secret".Sha256())},
            AllowedScopes=new List<string>{ IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile}
        }
    };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] {
        new ApiScope("movieAPI","Movie API") };

    public static IEnumerable<ApiResource> ApiResources => new ApiResource[] { };

    public static IEnumerable<IdentityResource> IdentityResources
        => new IdentityResource[] {
                                    new IdentityResources.OpenId(),
                                    new IdentityResources.Profile()
                                    };

    public static List<TestUser> TestUsers => new List<TestUser> {
            new TestUser{
                SubjectId="",
                Username="milad",
                Password="3252179",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.GivenName,"milad"),
                    new Claim(JwtClaimTypes.FamilyName,"nematpour")
                }
                }
    };
}