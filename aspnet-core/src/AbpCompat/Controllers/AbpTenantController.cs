using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class AbpTenantController : ApiController
	{
		[HttpGet]
		[Route("api/abp/multi-tenancy/tenants/by-name/{name}", Name = "by-name")]
		public Task<FindTenantResultDto> ByName(string name)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/abp/multi-tenancy/tenants/by-id/{id}", Name = "by-id")]
		public Task<FindTenantResultDto> ById(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
