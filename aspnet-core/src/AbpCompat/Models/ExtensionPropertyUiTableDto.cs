using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyUiTableDto
	{
		public bool IsVisible { get; set; }

		public ExtensionPropertyUiTableDto() { }
		[JsonConstructor]
		public ExtensionPropertyUiTableDto(bool isVisible)
		{
			IsVisible = isVisible;
		}
	}
}
