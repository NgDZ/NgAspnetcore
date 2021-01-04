using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class LoginController : ApiController
	{
		[HttpPost]
		[Route("api/account/login", Name = "login")]
		public Task<AbpLoginResult> Login([FromBody] UserLoginInfo body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/account/logout", Name = "logout")]
		public Task Logout()
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPost]
		[Route("api/account/check-password", Name = "check-password")]
		public Task<AbpLoginResult> CheckPassword([FromBody] UserLoginInfo body)
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
