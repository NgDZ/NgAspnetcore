using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public class UserLookupController : ApiController
	{
		[HttpGet]
		[Route("api/identity/users/lookup/{id}", Name = "lookup")]
		public Task<UserData> Lookup(Guid id)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/identity/users/lookup/by-username/{userName}", Name = "by-username2")]
		public Task<UserData> ByUsername(string userName)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/identity/users/lookup/search", Name = "search")]
		public Task<UserDataListResultDto> Search([FromQuery] string filter, [FromQuery] string sorting, [FromQuery] int? skipCount, [FromQuery] int? maxResultCount)
		{
			throw new NotImplementedException("not implement api");
		}

		[HttpGet]
		[Route("api/identity/users/lookup/count", Name = "count")]
		public Task<long> Count([FromQuery] string filter)
		{
			throw new NotImplementedException("not implement api");
		}
	}
}
