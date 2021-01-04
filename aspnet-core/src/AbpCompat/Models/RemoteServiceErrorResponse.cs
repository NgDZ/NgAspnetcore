using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class RemoteServiceErrorResponse
	{
		public RemoteServiceErrorInfo Error { get; set; }

		public RemoteServiceErrorResponse() { }
		[JsonConstructor]
		public RemoteServiceErrorResponse(RemoteServiceErrorInfo error)
		{
			Error = error;
		}
	}
}
