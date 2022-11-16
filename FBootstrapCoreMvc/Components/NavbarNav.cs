using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarNav : Component<NavbarNav>,
        ICanCreate<NavbarLink>,
        ICanCreate<NavbarDropdown>
    {
        public NavbarNav(IHtmlHelper helper)
            : base(helper, "ul", Css.NavbarNav, Css.MeAuto)
        {
        }
    }
}