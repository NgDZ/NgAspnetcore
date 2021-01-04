using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class MultiTenancyInfoDto
	{
		public bool IsEnabled { get; set; }

		public MultiTenancyInfoDto() { }
		[JsonConstructor]
		public MultiTenancyInfoDto(bool isEnabled)
		{
			IsEnabled = isEnabled;
		}
	}
}
