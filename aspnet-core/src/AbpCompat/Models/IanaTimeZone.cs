using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IanaTimeZone
	{
		public string TimeZoneName
		{
			get;
		}

		[JsonConstructor]
		public IanaTimeZone(string timeZoneName)
		{
			TimeZoneName = timeZoneName;
		}
	}
}
