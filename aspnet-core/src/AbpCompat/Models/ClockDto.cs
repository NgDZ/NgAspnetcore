using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ClockDto
	{
		public string Kind { get; set; }

		public ClockDto() { }
		[JsonConstructor]
		public ClockDto(string kind)
		{
			Kind = kind;
		}
	}
}
