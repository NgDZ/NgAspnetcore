using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class SendPasswordResetCodeDto
	{
		public string Email { get; set; }

		public string AppName { get; set; }

		public string ReturnUrl { get; set; }

		public string ReturnUrlHash { get; set; }

		public SendPasswordResetCodeDto() { }
		[JsonConstructor]
		public SendPasswordResetCodeDto(string appName, string email, string returnUrl, string returnUrlHash)
		{
			Email = email;
			AppName = appName;
			ReturnUrl = returnUrl;
			ReturnUrlHash = returnUrlHash;
		}
	}
}
