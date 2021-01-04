using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ClockDto
	{
		public string Kind
		{
			get;
		}

		[JsonConstructor]
		public ClockDto(string kind)
		{
			Kind = kind;
		}
	}
}
