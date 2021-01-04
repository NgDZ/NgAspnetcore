using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class DateTimeFormatDto
	{
		public string CalendarAlgorithmType
		{
			get;
		}

		public string DateTimeFormatLong
		{
			get;
		}

		public string ShortDatePattern
		{
			get;
		}

		public string FullDateTimePattern
		{
			get;
		}

		public string DateSeparator
		{
			get;
		}

		public string ShortTimePattern
		{
			get;
		}

		public string LongTimePattern
		{
			get;
		}

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
