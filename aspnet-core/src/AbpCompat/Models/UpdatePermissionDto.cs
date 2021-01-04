using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class UpdatePermissionDto
	{
		public string Name
		{
			get;
		}

		public bool IsGranted
		{
			get;
		}

		[JsonConstructor]
		public UpdatePermissionDto(bool isGranted, string name)
		{
			Name = name;
			IsGranted = isGranted;
		}
	}
}
