using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarNav : SingleComponent,
        ICanCreate<NavbarLink>,
        ICanCreate<NavbarDropdown>
    {
        public NavbarNav()
            : base("ul", Css.NavbarNav, Css.MeAuto)
        {
        }
    }
}