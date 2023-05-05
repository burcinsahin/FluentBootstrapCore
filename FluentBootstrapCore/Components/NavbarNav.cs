using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
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