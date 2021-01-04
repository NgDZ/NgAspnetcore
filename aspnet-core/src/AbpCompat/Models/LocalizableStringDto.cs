using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class LocalizableStringDto
	{
		public string Name
		{
			get;
		}

		public string Resource
		{
			get;
		}

		[JsonConstructor]
		public LocalizableStringDto(string name, string resource)
		{
			Name = name;
			Resource = resource;
		}
	}
}
