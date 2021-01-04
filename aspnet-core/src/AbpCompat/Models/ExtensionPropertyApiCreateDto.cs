using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyApiCreateDto
	{
		public bool IsAvailable
		{
			get;
		}

		[JsonConstructor]
		public ExtensionPropertyApiCreateDto(bool isAvailable)
		{
			IsAvailable = isAvailable;
		}
	}
}
