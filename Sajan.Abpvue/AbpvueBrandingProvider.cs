using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Sajan.Abpvue;

[Dependency(ReplaceServices = true)]
public class AbpvueBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Abpvue";
}
