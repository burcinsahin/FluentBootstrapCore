using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarNav : BootstrapComponent,
        ICanCreate<NavbarLink>,
        ICanCreate<NavbarDropdown>
    {
        public NavbarNav()
            : base("ul", Css.NavbarNav, Css.MeAuto)
        {
        }
    }
}