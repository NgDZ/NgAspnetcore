using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyApiDto
	{
		public ExtensionPropertyApiGetDto OnGet
		{
			get;
		}

		public ExtensionPropertyApiCreateDto OnCreate
		{
			get;
		}

		public ExtensionPropertyApiUpdateDto OnUpdate
		{
			get;
		}

		[JsonConstructor]
		public ExtensionPropertyApiDto(ExtensionPropertyApiCreateDto onCreate, ExtensionPropertyApiGetDto onGet, ExtensionPropertyApiUpdateDto onUpdate)
		{
			OnGet = onGet;
			OnCreate = onCreate;
			OnUpdate = onUpdate;
		}
	}
}
