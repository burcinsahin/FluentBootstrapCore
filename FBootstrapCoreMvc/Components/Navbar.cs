using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Navbar : HtmlComponent,
        ICanCreate<NavbarBrand>,
        ICanCreate<NavbarCollapse>,
        ICanCreate<NavbarToggler>
    {
        public Navbar()
            : base("nav", Css.Navbar, Css.NavbarExpandLg, Css.NavbarDark, Css.BgDark)
        {
        }
    }
}