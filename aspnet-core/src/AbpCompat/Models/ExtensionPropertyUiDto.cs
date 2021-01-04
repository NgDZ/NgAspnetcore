using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyUiDto
	{
		public ExtensionPropertyUiTableDto OnTable { get; set; }

		public ExtensionPropertyUiFormDto OnCreateForm { get; set; }

		public ExtensionPropertyUiFormDto OnEditForm { get; set; }

		public ExtensionPropertyUiLookupDto Lookup { get; set; }

		public ExtensionPropertyUiDto() { }
		[JsonConstructor]
		public ExtensionPropertyUiDto(ExtensionPropertyUiLookupDto lookup, ExtensionPropertyUiFormDto onCreateForm, ExtensionPropertyUiFormDto onEditForm, ExtensionPropertyUiTableDto onTable)
		{
			OnTable = onTable;
			OnCreateForm = onCreateForm;
			OnEditForm = onEditForm;
			Lookup = lookup;
		}
	}
}
