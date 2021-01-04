using System.Text.Json.Serialization;

namespace AbpCompat
{
	public class ApplicationConfigurationDto
	{
		public ApplicationLocalizationConfigurationDto Localization
		{
			get;
		}

		public ApplicationAuthConfigurationDto Auth
		{
			get;
		}

		public ApplicationSettingConfigurationDto Setting
		{
			get;
		}

		public CurrentUserDto CurrentUser
		{
			get;
		}

		public ApplicationFeatureConfigurationDto Features
		{
			get;
		}

		public MultiTenancyInfoDto MultiTenancy
		{
			get;
		}

		public CurrentTenantDto CurrentTenant
		{
			get;
		}

		public TimingDto Timing
		{
			get;
		}

		public ClockDto Clock
		{
			get;
		}

		public ObjectExtensionsDto ObjectExtensions
		{
			get;
		}

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
