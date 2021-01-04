using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class AccountController : ApiController
	{
		[HttpPost]
		[Route("api/account/register", Name = "register")]
		public Task<IdentityUserDto> Register([FromBody] RegisterDto body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPost]
		[Route("api/account/send-password-reset-code", Name = "send-password-reset-code")]
		public Task SendPasswordResetCode([FromBody] SendPasswordResetCodeDto body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPost]
		[Route("api/account/reset-password", Name = "reset-password")]
		public Task ResetPassword([FromBody] ResetPasswordDto body)
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
