using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NgAspnetcore.Models;

namespace NgAspnetcore
{
    public class LocalIdentityServerPasswordValidator<TUser> : IPasswordValidator<TUser>
           where TUser : class
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager,
                                                  TUser user,
                                                  string password)
        {
            Console.WriteLine(password);
            return Task.FromResult(password.Distinct().Count() == 1 ?
                IdentityResult.Failed(new IdentityError
                {
                    Code = "SameChar",
                    Description = "Passwords cannot be all the same character."
                }) :
                IdentityResult.Success);
        }
    }
    public static class IdentityServerConfig2
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                   new ApiResource("client", "Default (all) API"){
                        Scopes= new List< string>(){
                          "client"
                        },
                        UserClaims = {
                            "nbf",
                            "exp",
                            "iss",
                            "aud",
                            "aud",
                            "client_id",
                            "sub",
                            "auth_time",
                            "idp",
                            "AspNet.Identity.SecurityStamp",
                            ClaimTypes.Role,
                            ClaimTypes.Name,
                            ClaimTypes.Authentication,
                            ClaimTypes.GivenName,
                            ClaimTypes.Email,
                            ClaimTypes.Gender,
                            "name",
                            "email",
                            "email_verified",
                            "scope"
                            }
                   }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone()
            };
        }

        public static IEnumerable<Client> GetClients(object O = null)
        {
            return new List<Client>
            {
                new Client
               {

                    ClientId = "AngularSPA_App",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, // Resource Owner Password Credential grant.
                    AllowAccessTokensViaBrowser = true,
                    RequireClientSecret = true, // This client does not need a secret to request tokens from the token endpoint.

                    ClientSecrets = { new Secret("1q2w3e*".Sha256()) },
                    AccessTokenLifetime = 3600, // Lifetime of access token in seconds.

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId, // For UserInfo endpoint.
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "roles",
                        "client"
                    },
                    AllowOfflineAccess = true, // For refresh token.
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    // AbsoluteRefreshTokenLifetime = 20,
                    SlidingRefreshTokenLifetime = 3*3600,
                    RefreshTokenExpiration = TokenExpiration.Sliding
               }
            };
        }
    }
}
