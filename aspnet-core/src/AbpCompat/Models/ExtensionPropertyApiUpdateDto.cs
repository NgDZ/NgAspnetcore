using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyApiUpdateDto
	{
		public bool IsAvailable
		{
			get;
		}

		[JsonConstructor]
		public ExtensionPropertyApiUpdateDto(bool isAvailable)
		{
			IsAvailable = isAvailable;
		}
	}
}
