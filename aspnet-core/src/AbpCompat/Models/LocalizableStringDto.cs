using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class LocalizableStringDto
	{
		public string Name { get; set; }

		public string Resource { get; set; }

		public LocalizableStringDto() { }
		[JsonConstructor]
		public LocalizableStringDto(string name, string resource)
		{
			Name = name;
			Resource = resource;
		}
	}
}
