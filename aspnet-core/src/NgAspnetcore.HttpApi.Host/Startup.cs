using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using NgAspnetcore.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.IdentityModel.Tokens;

namespace NgAspnetcore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<Northwind.NorthwindDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("NorthwindConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
                .AddInMemoryApiResources(IdentityServerConfig2.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig2.GetClients())
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();
            services.AddTransient<ResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
            services.AddRouting();

            // services.AddOData(opt => opt.AddModel("Northwind", Northwind.NothwindDbContext.GetEdmModel()));

            services.AddMvc(options =>
            {
                // options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName));
                options.OutputFormatters.Add(new BreezeJsonProfileFormatter(options));
            })
                // .AddNewtonsoftJson(options =>
                // {
                //     // options.SerializerSettings.ContractResolver =
                //     //     new AbpMvcJsonContractResolver(context.Services);

                //     options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                //     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                // })
                ;

#if DEBUG
            services.ConfigureDevCode();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
#if DEBUG

            app.UseDevCode();
#endif
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
#if !DEBUG
                endpoints.MapFallbackToController("Index", "AngularHome");
#endif
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
