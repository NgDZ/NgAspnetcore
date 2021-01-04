using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyUiFormDto
	{
		public bool IsVisible
		{
			get;
		}

		[JsonConstructor]
		public ExtensionPropertyUiFormDto(bool isVisible)
		{
			IsVisible = isVisible;
		}
	}
}
