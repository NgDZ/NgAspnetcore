using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AbpCompat
{
    public class ApplicationFeatureConfigurationDto
    {
        public IDictionary<string, string> Values { get; set; }

        public ApplicationFeatureConfigurationDto() { }

        public ApplicationFeatureConfigurationDto(IDictionary<string, string> values)
        {
            Values = values;
        }
    }
}
