using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FREETIME.EntityFrameworkCore;
using FREETIME.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using Microsoft.Extensions.DependencyInjection.Extensions;
using IdentityServer4.Validation;
using Volo.Abp.Uow;
using FREETIME;
using Northwind;
#if DEBUG
using Microsoft.OpenApi.Models;
using Volo.Abp.Swashbuckle;
#endif
namespace NgAspnetcore
{
    [DependsOn(
        typeof(FREETIMEHttpApiModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(FREETIMEApplicationModule),
        typeof(FREETIMEEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpDz.IdentityServer.AbpDzIdentityServerModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpDz.Breeze.AbpDzBreezeModule),
        typeof(NorthwindHostingModule),
#if DEBUG
        typeof(AbpSwashbuckleModule),
#endif
        typeof(AbpAspNetCoreSerilogModule)
    )]
    public class FREETIMEHttpApiHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            var configuration = context.Services.GetConfiguration();
            configuration.SetHostEvirementSettings("FREETIME");
            var hostingEnvirofrnment = context.Services.GetHostingEnvironment();

            ConfigureBundles();
            ConfigureUrls(configuration);
            ConfigureConventionalControllers();
            ConfigureAuthentication(context, configuration);
            ConfigureLocalization();
            ConfigureVirtualFileSystem(context);
            ConfigureCors(context, configuration);

#if DEBUG
            context.Services.ConfigureDevCode();
#endif
            context.Services.AddSignalR().AddNewtonsoftJsonProtocol();
            context.Services.AddResponseCompression();
            Configure<AbpUnitOfWorkDefaultOptions>(options =>
            {
                // only in sqlite 
                options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
            });
        }

        private void ConfigureBundles()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    BasicThemeBundles.Styles.Global,
                    bundle => { bundle.AddFiles("/global-styles.css"); }
                );
            });
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    try
                    {
                        options.FileSets.ReplaceEmbeddedByPhysical<FREETIMEDomainSharedModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}FREETIME.Domain.Shared"));
                        options.FileSets.ReplaceEmbeddedByPhysical<FREETIMEDomainModule>(
                            Path.Combine(hostingEnvironment.ContentRootPath,
                                $"..{Path.DirectorySeparatorChar}FREETIME.Domain"));
                        options.FileSets.ReplaceEmbeddedByPhysical<FREETIMEApplicationContractsModule>(
                            Path.Combine(hostingEnvironment.ContentRootPath,
                                $"..{Path.DirectorySeparatorChar}FREETIME.Application.Contracts"));
                        options.FileSets.ReplaceEmbeddedByPhysical<FREETIMEApplicationModule>(
                            Path.Combine(hostingEnvironment.ContentRootPath,
                                $"..{Path.DirectorySeparatorChar}FREETIME.Application"));
                    }
                    catch (System.Exception)
                    {
                    }
                });
            }
        }

        private void ConfigureConventionalControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(FREETIMEApplicationModule).Assembly);
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    var auth = configuration["AuthServer:Authority"];

                    var port = Environment.GetEnvironmentVariable("PORT");
                    if (!string.IsNullOrEmpty(port))
                    {
                        auth = "http://localhost:" + port;
                    }
                    options.Authority = auth;
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "IDS_CLIENT";
                    options.BackchannelHttpHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback =
                            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };
                });
        }



        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("ar", "ar", "???????"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("fr", "fr", "Fran�ais"));
            });
        }

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

#if DEBUG

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
#endif
            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            var fordwardedHeaderOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
            };
            fordwardedHeaderOptions.KnownNetworks.Clear();
            fordwardedHeaderOptions.KnownProxies.Clear();

            app.UseForwardedHeaders(fordwardedHeaderOptions);
#if DEBUG

            app.UseDevCode();
#endif
            app.UseResponseCompression();
            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName);
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseIdentityServer();
            app.UseAuthorization();


            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints(endpoints =>
         {
#if !DEBUG
                endpoints.MapFallbackToController("Index", "AngularHome");
#endif

             //  endpoints.MapHub<AbpDz.Notifications.AbpDzNotificationHub>("/abpdz-notification-hub", options =>
             //     {
             //     });
             // endpoints.MapHub<SignalRNotificationHub>("/signalr-notificationhub");
         });

#if DEBUG 
            app.UseSpa(spa =>
            {
                spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
            });
#endif
        }
    }
}
