using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TimeZone
	{
		public IanaTimeZone Iana { get; set; }

		public WindowsTimeZone Windows { get; set; }

		public TimeZone() { }
		[JsonConstructor]
		public TimeZone(IanaTimeZone iana, WindowsTimeZone windows)
		{
			Iana = iana;
			Windows = windows;
		}
	}
}
