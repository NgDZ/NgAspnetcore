using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyApiGetDto
	{
		public bool IsAvailable
		{
			get;
		}

		[JsonConstructor]
		public ExtensionPropertyApiGetDto(bool isAvailable)
		{
			IsAvailable = isAvailable;
		}
	}
}
