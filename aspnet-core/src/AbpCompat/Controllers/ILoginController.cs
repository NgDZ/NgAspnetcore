using System.Threading.Tasks;

namespace AbpCompat
{
	public interface ILoginController
	{
		Task<AbpLoginResult> LoginAsync(UserLoginInfo body);

		Task LogoutAsync();

		Task<AbpLoginResult> CheckPasswordAsync(UserLoginInfo body);
	}
}
