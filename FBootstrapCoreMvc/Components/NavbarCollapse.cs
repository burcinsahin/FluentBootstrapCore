using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarCollapse : HtmlComponent,
        ICanCreate<NavbarNav>
    {
        public NavbarCollapse(string? id) 
            : base("div", Css.Collapse, Css.NavbarCollapse)
        {
        }
    }
}