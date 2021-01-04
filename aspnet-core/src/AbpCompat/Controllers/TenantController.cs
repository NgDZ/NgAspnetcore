using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class TenantController : ApiController
	{
		[HttpGet]
		[Route("api/multi-tenancy/tenants/{id}", Name = "tenants")]
		public Task<TenantDto> TenantsGet(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPut]
		[Route("api/multi-tenancy/tenants/{id}", Name = "tenants2")]
		public Task<TenantDto> TenantsPut(Guid id, [FromBody] TenantUpdateDto body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpDelete]
		[Route("api/multi-tenancy/tenants/{id}", Name = "tenants3")]
		public Task TenantsDelete(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/multi-tenancy/tenants", Name = "tenants4")]
		public Task<TenantDtoPagedResultDto> TenantsGet([FromQuery] string filter, [FromQuery] string sorting, [FromQuery] int? skipCount, [FromQuery] int? maxResultCount)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPost]
		[Route("api/multi-tenancy/tenants", Name = "tenants5")]
		public Task<TenantDto> TenantsPost([FromBody] TenantCreateDto body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/multi-tenancy/tenants/{id}/default-connection-string", Name = "default-connection-string")]
		public Task<string> DefaultConnectionStringGet(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPut]
		[Route("api/multi-tenancy/tenants/{id}/default-connection-string", Name = "default-connection-string2")]
		public Task DefaultConnectionStringPut(Guid id, [FromQuery] string defaultConnectionString)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpDelete]
		[Route("api/multi-tenancy/tenants/{id}/default-connection-string", Name = "default-connection-string3")]
		public Task DefaultConnectionStringDelete(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
