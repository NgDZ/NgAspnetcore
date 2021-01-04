using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class ProfileController : ApiController
	{
		[HttpGet]
		[Route("api/identity/my-profile", Name = "my-profile")]
		public Task<ProfileDto> MyProfileGet()
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPut]
		[Route("api/identity/my-profile", Name = "my-profile2")]
		public Task<ProfileDto> MyProfilePut([FromBody] UpdateProfileDto body)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpPost]
		[Route("api/identity/my-profile/change-password", Name = "change-password")]
		public Task ChangePassword([FromBody] ChangePasswordInput body)
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
