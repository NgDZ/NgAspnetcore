using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyUiTableDto
	{
		public bool IsVisible
		{
			get;
		}

		[JsonConstructor]
		public ExtensionPropertyUiTableDto(bool isVisible)
		{
			IsVisible = isVisible;
		}
	}
}
