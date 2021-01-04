using System;
using System.Threading.Tasks;

namespace AbpCompat
{
	public interface IUserLookupController
	{
		Task<UserData> LookupAsync(Guid id);

		Task<UserData> ByUsernameAsync(string userName);

		Task<UserDataListResultDto> SearchAsync(string filter, string sorting, int? skipCount, int? maxResultCount);

		Task<long> CountAsync(string filter);
	}
}
