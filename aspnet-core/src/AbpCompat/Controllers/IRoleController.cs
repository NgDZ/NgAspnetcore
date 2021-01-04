using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public interface IRoleController
	{
		Task<IdentityRoleDtoListResultDto> AllAsync();

		Task<IdentityRoleDtoPagedResultDto> RolesGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount);

		Task<IdentityRoleDto> RolesPostAsync(IdentityRoleCreateDto body);

		Task<IdentityRoleDto> RolesGetAsync(Guid id);

		Task<IdentityRoleDto> RolesPutAsync(Guid id, IdentityRoleUpdateDto body);

		Task RolesDeleteAsync(Guid id);
	}
}
