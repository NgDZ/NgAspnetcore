using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyApiDto
	{
		public ExtensionPropertyApiGetDto OnGet { get; set; }

		public ExtensionPropertyApiCreateDto OnCreate { get; set; }

		public ExtensionPropertyApiUpdateDto OnUpdate { get; set; }

		public ExtensionPropertyApiDto() { }
		[JsonConstructor]
		public ExtensionPropertyApiDto(ExtensionPropertyApiCreateDto onCreate, ExtensionPropertyApiGetDto onGet, ExtensionPropertyApiUpdateDto onUpdate)
		{
			OnGet = onGet;
			OnCreate = onCreate;
			OnUpdate = onUpdate;
		}
	}
}
