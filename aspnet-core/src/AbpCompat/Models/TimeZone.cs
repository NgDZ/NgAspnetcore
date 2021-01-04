using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TimeZone
	{
		public IanaTimeZone Iana
		{
			get;
		}

		public WindowsTimeZone Windows
		{
			get;
		}

		[JsonConstructor]
		public TimeZone(IanaTimeZone iana, WindowsTimeZone windows)
		{
			Iana = iana;
			Windows = windows;
		}
	}
}
