using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarCollapse : SingleComponent,
        ICanCreate<NavbarNav>
    {
        public NavbarCollapse() 
            : base("div", Css.Collapse, Css.NavbarCollapse)
        {
        }
    }
}