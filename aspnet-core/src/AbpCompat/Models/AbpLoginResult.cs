using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class AbpLoginResult
	{
		public LoginResultType Result
		{
			get;
		}

		public string Description
		{
			get;
		}

		[JsonConstructor]
		public AbpLoginResult(string description, LoginResultType result)
		{
			Result = result;
			Description = description;
		}
	}
}
