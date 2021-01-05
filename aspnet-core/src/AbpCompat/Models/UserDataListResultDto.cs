using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UserDataListResultDto
	{
		public List<UserData> Items { get; set; }

		public UserDataListResultDto() { }
		[JsonConstructor]
		public UserDataListResultDto(List<UserData> items)
		{
			Items = items;
		}
	}
}