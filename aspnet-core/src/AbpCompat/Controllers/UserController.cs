using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class UserController : ApiController
	{
		[HttpGet]
		[Route("api/identity/users/{id}", Name = "users")]
		public Task<IdentityUserDto> UsersGet(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPut]
		[Route("api/identity/users/{id}", Name = "users2")]
		public Task<IdentityUserDto> UsersPut(Guid id, [FromBody] IdentityUserUpdateDto body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpDelete]
		[Route("api/identity/users/{id}", Name = "users3")]
		public Task UsersDelete(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/identity/users", Name = "users4")]
		public Task<IdentityUserDtoPagedResultDto> UsersGet([FromQuery] string filter, [FromQuery] string sorting, [FromQuery] int? skipCount, [FromQuery] int? maxResultCount)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPost]
		[Route("api/identity/users", Name = "users5")]
		public Task<IdentityUserDto> UsersPost([FromBody] IdentityUserCreateDto body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/identity/users/{id}/roles", Name = "roles6")]
		public Task<IdentityRoleDtoListResultDto> RolesGet(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPut]
		[Route("api/identity/users/{id}/roles", Name = "roles7")]
		public Task RolesPut(Guid id, [FromBody] IdentityUserUpdateRolesDto body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/identity/users/assignable-roles", Name = "assignable-roles")]
		public Task<IdentityRoleDtoListResultDto> AssignableRoles()
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/identity/users/by-username/{userName}", Name = "by-username")]
		public Task<IdentityUserDto> ByUsername(string userName)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/identity/users/by-email/{email}", Name = "by-email")]
		public Task<IdentityUserDto> ByEmail(string email)
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
