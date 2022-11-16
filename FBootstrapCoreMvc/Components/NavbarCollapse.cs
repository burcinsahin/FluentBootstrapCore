using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarCollapse : Component<NavbarCollapse>,
        ICanCreate<NavbarNav>
    {
        public NavbarCollapse(IHtmlHelper helper, string? id)
            : base(helper, "div", Css.Collapse, Css.NavbarCollapse)
        {
        }
    }
}