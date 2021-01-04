using System;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ResetPasswordDto
	{
		public Guid UserId
		{
			get;
		}

		public string ResetToken
		{
			get;
		}

		public string Password
		{
			get;
		}

		[JsonConstructor]
		public ResetPasswordDto(string password, string resetToken, Guid userId)
		{
			UserId = userId;
			ResetToken = resetToken;
			Password = password;
		}
	}
}
