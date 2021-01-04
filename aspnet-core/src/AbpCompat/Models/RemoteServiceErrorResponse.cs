using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class RemoteServiceErrorResponse
	{
		public RemoteServiceErrorInfo Error
		{
			get;
		}

		[JsonConstructor]
		public RemoteServiceErrorResponse(RemoteServiceErrorInfo error)
		{
			Error = error;
		}
	}
}
