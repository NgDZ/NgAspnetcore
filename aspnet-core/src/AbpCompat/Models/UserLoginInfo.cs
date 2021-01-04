using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UserLoginInfo
	{
		public string UserNameOrEmailAddress
		{
			get;
		}

		public string Password
		{
			get;
		}

		public bool RememberMe
		{
			get;
		}

		[JsonConstructor]
		public UserLoginInfo(string password, bool rememberMe, string userNameOrEmailAddress)
		{
			UserNameOrEmailAddress = userNameOrEmailAddress;
			Password = password;
			RememberMe = rememberMe;
		}
	}
}
