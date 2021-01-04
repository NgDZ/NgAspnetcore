using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class RoleController : ApiController
	{
		[HttpGet]
		[Route("api/identity/roles/all", Name = "all")]
		public Task<IdentityRoleDtoListResultDto> All()
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/identity/roles", Name = "roles")]
		public Task<IdentityRoleDtoPagedResultDto> RolesGet([FromQuery] string filter, [FromQuery] string sorting, [FromQuery] int? skipCount, [FromQuery] int? maxResultCount)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPost]
		[Route("api/identity/roles", Name = "roles2")]
		public Task<IdentityRoleDto> RolesPost([FromBody] IdentityRoleCreateDto body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/identity/roles/{id}", Name = "roles3")]
		public Task<IdentityRoleDto> RolesGet(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPut]
		[Route("api/identity/roles/{id}", Name = "roles4")]
		public Task<IdentityRoleDto> RolesPut(Guid id, [FromBody] IdentityRoleUpdateDto body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpDelete]
		[Route("api/identity/roles/{id}", Name = "roles5")]
		public Task RolesDelete(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
