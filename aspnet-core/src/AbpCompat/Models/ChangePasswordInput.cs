using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ChangePasswordInput
	{
		public string CurrentPassword
		{
			get;
		}

		public string NewPassword
		{
			get;
		}

		[JsonConstructor]
		public ChangePasswordInput(string currentPassword, string newPassword)
		{
			CurrentPassword = currentPassword;
			NewPassword = newPassword;
		}
	}
}
