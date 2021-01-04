using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public interface IUserController
	{
		Task<IdentityUserDto> UsersGetAsync(Guid id);

		Task<IdentityUserDto> UsersPutAsync(Guid id, IdentityUserUpdateDto body);

		Task UsersDeleteAsync(Guid id);

		Task<IdentityUserDtoPagedResultDto> UsersGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount);

		Task<IdentityUserDto> UsersPostAsync(IdentityUserCreateDto body);

		Task<IdentityRoleDtoListResultDto> RolesGetAsync(Guid id);

		Task RolesPutAsync(Guid id, IdentityUserUpdateRolesDto body);

		Task<IdentityRoleDtoListResultDto> AssignableRolesAsync();

		Task<IdentityUserDto> ByUsernameAsync(string userName);

		Task<IdentityUserDto> ByEmailAsync(string email);
	}
}
