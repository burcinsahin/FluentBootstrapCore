using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Navbar : Component<Navbar>,
        ICanCreate<NavbarBrand>,
        ICanCreate<NavbarCollapse>,
        ICanCreate<NavbarToggler>
    {
        public Navbar(IHtmlHelper helper)
            : base(helper, "nav", Css.Navbar, Css.NavbarExpandLg, Css.NavbarDark, Css.BgDark)
        {
        }
    }
}