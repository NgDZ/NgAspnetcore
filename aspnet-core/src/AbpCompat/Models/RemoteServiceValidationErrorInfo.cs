using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class RemoteServiceValidationErrorInfo
	{
		public string Message
		{
			get;
		}

		public List<string> Members
		{
			get;
		}

		[JsonConstructor]
		public RemoteServiceValidationErrorInfo(List<string> members, string message)
		{
			Message = message;
			Members = members;
		}
	}
}
