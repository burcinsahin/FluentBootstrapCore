using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Icon : Component<Icon>
    {
        public Icon(IHtmlHelper helper, IconType icon)
            : base(helper, "i")
        {
            AddCssClass($"bi bi-{icon.GetCssDescription()}");
        }
    }
}
