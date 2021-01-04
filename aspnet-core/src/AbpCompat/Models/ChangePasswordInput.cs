using System.Text.Json.Serialization;

namespace AbpCompat
{
    public class ChangePasswordInput
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public ChangePasswordInput() { }
        [JsonConstructor]
        public ChangePasswordInput(string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }
    }
}
