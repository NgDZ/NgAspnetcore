using System.Text.Json.Serialization;

namespace AbpCompat
{
    public class AbpLoginResult
    {
        public LoginResultType Result { get; set; }

        public string Description { get; set; }


        public AbpLoginResult() { }
        [JsonConstructor]
        public AbpLoginResult(string description, LoginResultType result)
        {
            Result = result;
            Description = description;
        }
    }
}
