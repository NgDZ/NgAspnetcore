using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TimingDto
	{
		public TimeZone TimeZone
		{
			get;
		}

		[JsonConstructor]
		public TimingDto(TimeZone timeZone)
		{
			TimeZone = timeZone;
		}
	}
}
