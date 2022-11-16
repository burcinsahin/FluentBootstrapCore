using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarDropdown : Component<NavbarDropdown>,
        ICanCreate<DropdownMenu>
    {
        public NavbarDropdown(IHtmlHelper helper, string text)
            : base(helper, "li", Css.NavItem, Css.Dropdown)
        {
            var link = new Link(helper, text);
            link.AddCss(Css.NavLink, Css.DropdownToggle)
                .SetHref("#")
                .SetRole("button")
                .AddAttribute("data-bs-toggle", "dropdown")
                .AddAttribute("aria-expanded", false);
            InnerHtml.AppendHtml(link);
        }
    }
}