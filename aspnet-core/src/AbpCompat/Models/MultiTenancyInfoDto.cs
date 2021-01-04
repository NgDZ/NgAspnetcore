using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class MultiTenancyInfoDto
	{
		public bool IsEnabled
		{
			get;
		}

		[JsonConstructor]
		public MultiTenancyInfoDto(bool isEnabled)
		{
			IsEnabled = isEnabled;
		}
	}
}
