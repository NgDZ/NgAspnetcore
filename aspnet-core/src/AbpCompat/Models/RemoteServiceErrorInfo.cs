using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class RemoteServiceErrorInfo
	{
		public string Code { get; set; }

		public string Message { get; set; }

		public string Details { get; set; }

		public IDictionary<string, object> Data { get; set; }

		public List<RemoteServiceValidationErrorInfo> ValidationErrors { get; set; }

		public RemoteServiceErrorInfo() { }
		[JsonConstructor]
		public RemoteServiceErrorInfo(string code, IDictionary<string, object> data, string details, string message, List<RemoteServiceValidationErrorInfo> validationErrors)
		{
			Code = code;
			Message = message;
			Details = details;
			Data = data;
			ValidationErrors = validationErrors;
		}
	}
}
