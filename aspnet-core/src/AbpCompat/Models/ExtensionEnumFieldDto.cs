using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionEnumFieldDto
	{
		public string Name
		{
			get;
		}

		public object Value
		{
			get;
		}

		[JsonConstructor]
		public ExtensionEnumFieldDto(string name, object value)
		{
			Name = name;
			Value = value;
		}
	}
}
