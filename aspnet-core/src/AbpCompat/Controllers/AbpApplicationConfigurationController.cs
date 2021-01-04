using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class AbpApplicationConfigurationController : ApiController
	{
		[HttpGet]
		[Route("api/abp/application-configuration", Name = "application-configuration")]
		public Task<ApplicationConfigurationDto> ApplicationConfiguration()
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
