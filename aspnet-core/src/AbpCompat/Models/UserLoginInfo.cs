using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UserLoginInfo
	{
		public string UserNameOrEmailAddress { get; set; }

		public string Password { get; set; }

		public bool RememberMe { get; set; }

		public UserLoginInfo() { }
		[JsonConstructor]
		public UserLoginInfo(string password, bool rememberMe, string userNameOrEmailAddress)
		{
			UserNameOrEmailAddress = userNameOrEmailAddress;
			Password = password;
			RememberMe = rememberMe;
		}
	}
}
