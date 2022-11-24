using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarNav : HtmlComponent,
        ICanCreate<NavbarLink>,
        ICanCreate<NavbarDropdown>
    {
        public NavbarNav()
            : base("ul", Css.NavbarNav, Css.MeAuto)
        {
        }
    }
}