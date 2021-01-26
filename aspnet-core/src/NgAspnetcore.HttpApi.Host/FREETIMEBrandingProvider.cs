using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;
using FREETIME;
namespace NgAspnetcore
{
    [Dependency(ReplaceServices = true)]
    public class FREETIMEBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "FREETIME";
    }
}
