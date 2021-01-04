using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class SendPasswordResetCodeDto
	{
		public string Email
		{
			get;
		}

		public string AppName
		{
			get;
		}

		public string ReturnUrl
		{
			get;
		}

		public string ReturnUrlHash
		{
			get;
		}

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
