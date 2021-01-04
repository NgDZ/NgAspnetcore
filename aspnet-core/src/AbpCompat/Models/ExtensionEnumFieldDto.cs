using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionEnumFieldDto
	{
		public string Name { get; set; }

		public object Value { get; set; }

		public ExtensionEnumFieldDto() { }
		[JsonConstructor]
		public ExtensionEnumFieldDto(string name, object value)
		{
			Name = name;
			Value = value;
		}
	}
}
