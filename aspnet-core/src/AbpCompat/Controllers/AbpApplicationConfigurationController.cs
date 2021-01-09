using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AbpCompat
{
    [ApiController]
    public class AbpApplicationConfigurationController : ControllerBase
    {
        [HttpGet]
        [Route("api/abp/application-configuration", Name = "application-configuration")]
        public async Task<ApplicationConfigurationDto> ApplicationConfiguration()
        {
            var ret = new ApplicationConfigurationDto();
            ret.CurrentUser = new CurrentUserDto()
            {
                IsAuthenticated = false
            };
            var v = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine($"{v}-{User.Identity.Name}");
            if (this.User != null)
            {
                ret.CurrentUser.UserName = this.User.Identity.Name;
            }
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            ret.Localization = new ApplicationLocalizationConfigurationDto()
            {
                Languages = new System.Collections.Generic.List<LanguageInfo>(){
                    new LanguageInfo(){
                        CultureName=culture.Name,
                        DisplayName=culture.DisplayName
                    }
                }
                ,
                CurrentCulture = new CurrentCultureDto()
                {
                    DisplayName = culture.DisplayName,
                    Name = culture.Name,
                    IsRightToLeft = culture.TextInfo.IsRightToLeft,
                    NativeName = culture.NativeName
                }
            };
            return ret;
        }
    }
}
