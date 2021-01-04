using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
    public class AbpApplicationConfigurationController : ApiController
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
            if (this.User != null)
            {
                ret.CurrentUser.UserName = this.User.Identity.Name;
            }
            return ret;
        }
    }
}
