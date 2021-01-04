using System.Text.Json.Serialization;

namespace AbpCompat
{
    public class ApplicationConfigurationDto
    {
        public ApplicationLocalizationConfigurationDto Localization { get; set; }

        public ApplicationAuthConfigurationDto Auth { get; set; }

        public ApplicationSettingConfigurationDto Setting { get; set; }

        public CurrentUserDto CurrentUser { get; set; }

        public ApplicationFeatureConfigurationDto Features { get; set; }

        public MultiTenancyInfoDto MultiTenancy { get; set; }

        public CurrentTenantDto CurrentTenant { get; set; }

        public TimingDto Timing { get; set; }

        public ClockDto Clock { get; set; }

        public ObjectExtensionsDto ObjectExtensions { get; set; }

        public ApplicationConfigurationDto() { }
        [JsonConstructor]
        public ApplicationConfigurationDto(ApplicationAuthConfigurationDto auth, ClockDto clock, CurrentTenantDto currentTenant, CurrentUserDto currentUser, ApplicationFeatureConfigurationDto features, ApplicationLocalizationConfigurationDto localization, MultiTenancyInfoDto multiTenancy, ObjectExtensionsDto objectExtensions, ApplicationSettingConfigurationDto setting, TimingDto timing)
        {
            Localization = localization;
            Auth = auth;
            Setting = setting;
            CurrentUser = currentUser;
            Features = features;
            MultiTenancy = multiTenancy;
            CurrentTenant = currentTenant;
            Timing = timing;
            Clock = clock;
            ObjectExtensions = objectExtensions;
        }
    }
}
