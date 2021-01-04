using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class IanaTimeZone
	{
		public string TimeZoneName { get; set; }

		public IanaTimeZone() { }
		[JsonConstructor]
		public IanaTimeZone(string timeZoneName)
		{
			TimeZoneName = timeZoneName;
		}
	}
}
