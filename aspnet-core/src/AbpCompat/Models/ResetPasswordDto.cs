using System;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ResetPasswordDto
	{
		public Guid UserId { get; set; }

		public string ResetToken { get; set; }

		public string Password { get; set; }

		public ResetPasswordDto() { }
		[JsonConstructor]
		public ResetPasswordDto(string password, string resetToken, Guid userId)
		{
			UserId = userId;
			ResetToken = resetToken;
			Password = password;
		}
	}
}
