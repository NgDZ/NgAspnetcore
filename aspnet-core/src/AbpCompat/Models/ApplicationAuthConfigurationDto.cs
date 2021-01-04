using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
    public class ApplicationAuthConfigurationDto
    {
        public IDictionary<string, bool> Policies { get; set; }

        public IDictionary<string, bool> GrantedPolicies { get; set; }

        [JsonConstructor]
        public ApplicationAuthConfigurationDto(IDictionary<string, bool> grantedPolicies, IDictionary<string, bool> policies)
        {
            Policies = policies;
            GrantedPolicies = grantedPolicies;
        }
    }
}
