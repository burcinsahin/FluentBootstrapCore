using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class NavbarDropdown : BootstrapComponent,
        ICanCreate<DropdownMenu>
    {
        public NavbarDropdown(string text)
            : base("li", Css.NavItem, Css.Dropdown)
        {
            Content = text;
        }

        protected override void PreBuild()
        {
            var link = new Link()
            {
                Href = "#",
                Role = "button",
                Content = Content
            };
            link.AddCss(Css.NavLink, Css.DropdownToggle);
            link.MergeAttribute("data-bs-toggle", "dropdown");
            link.MergeAttribute("aria-expanded", false);
            AddChild(link);

            Content = null;
            base.PreBuild();
        }
    }
}