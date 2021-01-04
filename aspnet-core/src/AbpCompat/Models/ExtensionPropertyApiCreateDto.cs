using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyApiCreateDto
	{
		public bool IsAvailable { get; set; }

		public ExtensionPropertyApiCreateDto() { }
		[JsonConstructor]
		public ExtensionPropertyApiCreateDto(bool isAvailable)
		{
			IsAvailable = isAvailable;
		}
	}
}
