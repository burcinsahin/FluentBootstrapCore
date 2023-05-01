using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class NavbarCollapse : BootstrapComponent,
        ICanCreate<NavbarNav>
    {
        public NavbarCollapse()
            : base("div", Css.Collapse, Css.NavbarCollapse)
        {
        }
    }
}