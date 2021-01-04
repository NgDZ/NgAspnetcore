using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class RegisterDto
	{
		public string UserName { get; set; }

		public string EmailAddress { get; set; }

		public string Password { get; set; }

		public string AppName { get; set; }

		public RegisterDto() { }
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
