using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ExtensionPropertyUiDto
	{
		public ExtensionPropertyUiTableDto OnTable
		{
			get;
		}

		public ExtensionPropertyUiFormDto OnCreateForm
		{
			get;
		}

		public ExtensionPropertyUiFormDto OnEditForm
		{
			get;
		}

		public ExtensionPropertyUiLookupDto Lookup
		{
			get;
		}

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
