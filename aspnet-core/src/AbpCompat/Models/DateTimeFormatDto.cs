using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class DateTimeFormatDto
	{
		public string CalendarAlgorithmType { get; set; }

		public string DateTimeFormatLong { get; set; }

		public string ShortDatePattern { get; set; }

		public string FullDateTimePattern { get; set; }

		public string DateSeparator { get; set; }

		public string ShortTimePattern { get; set; }

		public string LongTimePattern { get; set; }

		public DateTimeFormatDto() { }
		[JsonConstructor]
		public DateTimeFormatDto(string calendarAlgorithmType, string dateSeparator, string dateTimeFormatLong, string fullDateTimePattern, string longTimePattern, string shortDatePattern, string shortTimePattern)
		{
			CalendarAlgorithmType = calendarAlgorithmType;
			DateTimeFormatLong = dateTimeFormatLong;
			ShortDatePattern = shortDatePattern;
			FullDateTimePattern = fullDateTimePattern;
			DateSeparator = dateSeparator;
			ShortTimePattern = shortTimePattern;
			LongTimePattern = longTimePattern;
		}
	}
}
