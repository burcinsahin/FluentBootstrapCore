using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarDropdown : HtmlComponent,
        ICanCreate<DropdownMenu>
    {
        public NavbarDropdown(string text)
            : base("li", Css.NavItem, Css.Dropdown)
        {
            var link = new Link(text);
            link.AddCss(Css.NavLink, Css.DropdownToggle);
            link.SetHref("#");
            link.SetRole("button");
            link.MergeAttribute("data-bs-toggle", "dropdown");
            link.MergeAttribute("aria-expanded", false);
            AddChild(link);
        }
    }
}