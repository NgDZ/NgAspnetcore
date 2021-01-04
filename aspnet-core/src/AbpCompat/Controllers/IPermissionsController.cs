using System.Threading.Tasks;

namespace AbpCompat
{
	public interface IPermissionsController
	{
		Task<GetPermissionListResultDto> PermissionsGetAsync(string providerName, string providerKey);

		Task PermissionsPutAsync(string providerName, string providerKey, UpdatePermissionsDto body);
	}
}
