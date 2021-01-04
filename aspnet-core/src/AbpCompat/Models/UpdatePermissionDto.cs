using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UpdatePermissionDto
	{
		public string Name { get; set; }

		public bool IsGranted { get; set; }

		public UpdatePermissionDto() { }
		[JsonConstructor]
		public UpdatePermissionDto(bool isGranted, string name)
		{
			Name = name;
			IsGranted = isGranted;
		}
	}
}
