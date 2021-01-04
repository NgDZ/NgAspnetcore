using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class RegisterDto
	{
		public string UserName
		{
			get;
		}

		public string EmailAddress
		{
			get;
		}

		public string Password
		{
			get;
		}

		public string AppName
		{
			get;
		}

		[JsonConstructor]
		public RegisterDto(string appName, string emailAddress, string password, string userName)
		{
			UserName = userName;
			EmailAddress = emailAddress;
			Password = password;
			AppName = appName;
		}
	}
}
