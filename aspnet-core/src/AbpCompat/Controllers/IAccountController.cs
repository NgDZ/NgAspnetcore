using System.Threading.Tasks;

namespace AbpCompat
{
	public interface IAccountController
	{
		Task<IdentityUserDto> RegisterAsync(RegisterDto body);

		Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto body);

		Task ResetPasswordAsync(ResetPasswordDto body);
	}
}
