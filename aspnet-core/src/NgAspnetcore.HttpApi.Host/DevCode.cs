#if DEBUG 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace NgAspnetcore
{
    public static class DevCodeExtension
    {
        public static HashSet<string> hsIgnoredDocs = new HashSet<string>()
        {
            // "AbpApplicationConfiguration","Account","Profile" ,"Login","IdentityUser","Tenant","IdentityRole"
        };
        public static HashSet<string> ApiExplorerGroupes = new HashSet<string>(){
            "All",
            "v1",
            "docs",
            "Config",
            "Profile",
            "Northwind"
        };
        public static void ConfigureDevCode(this IServiceCollection service)
        {
            ConfigureSwaggerServices(service);
            service
            .AddMiniProfiler(options =>
           {
               options.RouteBasePath = "/profiler";
               options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.VerboseSqlServerFormatter(true);
               options.TrackConnectionOpenClose = true;
               options.ColorScheme = StackExchange.Profiling.ColorScheme.Auto;
               options.EnableMvcFilterProfiling = true;
               options.EnableDebugMode = true;
               options.EnableServerTimingHeader = true;
               options.EnableMvcViewProfiling = true;

               (options.Storage as StackExchange.Profiling.Storage.MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(60);

           })
           .AddEntityFramework();
        }
        public static void UseDevCodeLog(this IApplicationBuilder app)
        {

            app.UseMiniProfiler();

        }
        public static void UseDevCode(this IApplicationBuilder app)
        {

            app.UseMiniProfiler();
            app.UseSwagger(c =>
            {
                // c.SerializeAsV2 = true;
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var item in ApiExplorerGroupes)
                {
                    options.SwaggerEndpoint("/swagger/" + item + "/swagger.json", "" + item);
                }

                options.InjectJavascript("/miniprofiler.js");
                options.RoutePrefix = "swagger";


            });
        }

        private static void ConfigureSwaggerServices(this IServiceCollection service)
        {

            service.AddSwaggerGen(
                options =>
                {

                    options.OperationFilter<HttpHeaderOperationFilter>();

                    foreach (var item in ApiExplorerGroupes)
                    {

                        options.SwaggerDoc(item, new OpenApiInfo
                        {
                            Title = "" + item,
                            Version = "1.0.0",
                            Description = "" + item
                        });
                    }

                    options.DocInclusionPredicate((docName, description) =>
                    {
                        var nm = description.ActionDescriptor.ToString().ToLower();
                        var groupName = description.GroupName;
                        if (groupName == "AbpApiDefinition") return false;
                        if (docName == "docs")
                        {

                            if (hsIgnoredDocs.Contains(groupName)) return false;

                            return true;
                        }
                        if (docName == "All" || docName == "v1") return true;
                        if (string.IsNullOrWhiteSpace(description.GroupName))
                        {
                            var attribute = description.ActionDescriptor.EndpointMetadata.OfType<ApiExplorerSettingsAttribute>().FirstOrDefault();
                            if (attribute != null)
                            {
                                groupName = attribute.GroupName;
                            }
                        }
                        if (docName == "Default")
                        {
                            return string.IsNullOrWhiteSpace(groupName) || groupName == "Default";
                        }
                        if (!string.IsNullOrWhiteSpace(groupName))
                        {
                            if (!ApiExplorerGroupes.Contains(groupName))
                            {
                                System.Console.WriteLine(groupName);
                            }
                            if (groupName == docName) return true;
                        }

                        return false;
                    });


                });
        }

    }

    public class HttpHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            if (context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
            {
                if (!methodInfo.CustomAttributes.Any(t => t.AttributeType == typeof(AllowAnonymousAttribute))
                  && !(methodInfo.ReflectedType.CustomAttributes.Any(t => t.AttributeType == typeof(AuthorizeAttribute))))
                {
                    // operation.Parameters.Add(new NonBodyParameter
                    // {
                    //     Name = "Authorization",
                    //     In = "header",
                    //     Type = "string",
                    //     Required = true,
                    //     Description = "Please enter Token in bearer XXX"
                    // });
                }
            }
        }


    }
}
#endif
