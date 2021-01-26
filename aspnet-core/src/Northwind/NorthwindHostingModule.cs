using System;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Northwind
{
    [DependsOn(
        typeof(AbpAccountApplicationModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule)
    )]
    public class NorthwindHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var Configuration = context.Services.GetConfiguration();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<NorthwindHostingModule>();
            });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(NorthwindHostingModule).Assembly);
            });
            context.Services.AddDbContext<Northwind.NorthwindDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("NorthwindConnection")));

        }
    }
}
