using System.Threading.Tasks;

namespace AbpCompat
{
	public interface IProfileController
	{
		Task<ProfileDto> MyProfileGetAsync();

		Task<ProfileDto> MyProfilePutAsync(UpdateProfileDto body);

		Task ChangePasswordAsync(ChangePasswordInput body);
	}
}
