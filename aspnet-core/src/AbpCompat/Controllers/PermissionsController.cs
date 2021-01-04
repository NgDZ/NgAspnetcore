using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class PermissionsController : ApiController
	{
		[HttpGet]
		[Route("api/permission-management/permissions", Name = "permissions")]
		public Task<GetPermissionListResultDto> PermissionsGet([FromQuery] string providerName, [FromQuery] string providerKey)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPut]
		[Route("api/permission-management/permissions", Name = "permissions2")]
		public Task PermissionsPut([FromQuery] string providerName, [FromQuery] string providerKey, [FromBody] UpdatePermissionsDto body)
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
