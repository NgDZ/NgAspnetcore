using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NgAspnetcore.Models;
using static IdentityModel.OidcConstants;

namespace NgAspnetcore
{
    public static class CustomIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddCustomUserStore(this IIdentityServerBuilder builder)
        {

            // builder.AddResourceOwnerValidator<ResourceOwnerPasswordValidator<>();

            return builder;
        }
    }
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator

    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ResourceOwnerPasswordValidator> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOwnerPasswordValidator{ApplicationUser}"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="logger">The logger.</param>
        public ResourceOwnerPasswordValidator(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor httpContextAccessor,

            ILogger<ResourceOwnerPasswordValidator> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        /// <summary>
        /// Validates the resource owner password credential
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public virtual async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userManager.FindByNameAsync(context.UserName);
            if (user != null)
            {
                Console.WriteLine(context.Password);
                var result = await _signInManager.CheckPasswordSignInAsync(user, context.Password, true);

                var resetPassResult = _userManager.PasswordHasher.HashPassword(user, user.UserName);
                System.Console.WriteLine(resetPassResult);
                if (result.Succeeded)
                {
                    var sub = await _userManager.GetUserIdAsync(user);
                    var form = this.httpContextAccessor.HttpContext.Request.Form;
                    if (form.ContainsKey("2F_CODE") && form["2F_CODE"] != "0123456")
                    {
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Invalid two factor code");
                        return;

                    }
                    // _logger.LogInformation("Credentials validated for username: {username}", context.UserName);

                    context.Result = new GrantValidationResult(sub, AuthenticationMethods.Password);
                    return;

                }
                else if (result.IsLockedOut)
                {
                    _logger.LogInformation("Authentication failed for username: {username}, reason: locked out", context.UserName);
                }
                else if (result.IsNotAllowed)
                {
                    _logger.LogInformation("Authentication failed for username: {username}, reason: not allowed", context.UserName);
                }
                else
                {
                    _logger.LogInformation("Authentication failed for username: {username}, reason: invalid credentials", context.UserName);
                }
            }
            else
            {
                _logger.LogInformation("No user found matching username: {username}", context.UserName);
            }

            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
        }
    }
    public static class IdentityServerConfig2
    {
        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResources.Phone()
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
                {
                    new ApiScope("IDS_CLIENT", "IDS_CLIENT")
                };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                   new ApiResource("IDS_CLIENT", "IDS_CLIENT"){
                        Scopes= new List< string>(){
                          "IDS_CLIENT"
                        },
                        UserClaims = {
                            ClaimTypes.Role,
                            ClaimTypes.Name,
                            ClaimTypes.Authentication,
                            ClaimTypes.GivenName,
                            ClaimTypes.Email,
                            ClaimTypes.Gender
                            }
                   }
            };
        }


        public static IEnumerable<Client> GetClients(object O = null)
        {
            return new List<Client>
            {
                new Client
               {

                    ClientId = "IDS_CLIENT_App",
                    AllowedGrantTypes =IdentityServer4.Models. GrantTypes.ResourceOwnerPassword, // Resource Owner Password Credential grant.
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
                            ClaimTypes.Role,
                            ClaimTypes.Name,
                            ClaimTypes.Authentication,
                            ClaimTypes.GivenName,
                            ClaimTypes.Email,
                            ClaimTypes.Gender,

                        "IDS_CLIENT"
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
