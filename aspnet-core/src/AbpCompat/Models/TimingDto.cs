using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class TimingDto
	{
		public TimeZone TimeZone { get; set; }

		public TimingDto() { }
		[JsonConstructor]
		public TimingDto(TimeZone timeZone)
		{
			TimeZone = timeZone;
		}
	}
}
