using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class WindowsTimeZone
	{
		public string TimeZoneId
		{
			get;
		}

		[JsonConstructor]
		public WindowsTimeZone(string timeZoneId)
		{
			TimeZoneId = timeZoneId;
		}
	}
}
