using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ApplicationSettingConfigurationDto
	{
		public IDictionary<string, string> Values
		{
			get;
		}

		[JsonConstructor]
		public ApplicationSettingConfigurationDto(IDictionary<string, string> values)
		{
			Values = values;
		}
	}
}
