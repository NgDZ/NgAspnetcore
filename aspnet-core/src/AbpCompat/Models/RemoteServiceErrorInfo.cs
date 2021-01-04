using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class RemoteServiceErrorInfo
	{
		public string Code
		{
			get;
		}

		public string Message
		{
			get;
		}

		public string Details
		{
			get;
		}

		public IDictionary<string, object> Data
		{
			get;
		}

		public List<RemoteServiceValidationErrorInfo> ValidationErrors
		{
			get;
		}

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
