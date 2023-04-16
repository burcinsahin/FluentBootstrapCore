namespace FBootstrapCoreMvc.Components
{
    public class NavbarLink : BootstrapComponent
    {
        private Link _link;

        public NavbarLink(string? text)
            : base("li", Css.NavItem)
        {
            _link = new Link(text);
            _link.AddCss(Css.NavLink);
            AddChild(_link);
        }

        public NavbarLink SetActive()
        {
            _link.AddCss(Css.Active);
            _link.MergeAttribute("aria-current", "page");
            return this;
        }

        public NavbarLink SetHref(string href)
        {
            _link.MergeAttribute("href", href);
            return this;
        }
    }
}