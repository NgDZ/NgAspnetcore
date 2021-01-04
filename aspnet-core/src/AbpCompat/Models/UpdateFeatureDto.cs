using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UpdateFeatureDto
	{
		public string Name
		{
			get;
		}

		public string Value
		{
			get;
		}

		[JsonConstructor]
		public UpdateFeatureDto(string name, string value)
		{
			Name = name;
			Value = value;
		}
	}
}
