using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyApiUpdateDto
	{
		public bool IsAvailable { get; set; }

		public ExtensionPropertyApiUpdateDto() { }
		[JsonConstructor]
		public ExtensionPropertyApiUpdateDto(bool isAvailable)
		{
			IsAvailable = isAvailable;
		}
	}
}
