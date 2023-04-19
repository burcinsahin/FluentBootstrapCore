using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarLink : BootstrapComponent, ILink, ICanBeActive
    {
        public string? Href { get; set; }
        public bool Active { get; set; }

        public NavbarLink(string? text)
            : base("li", Css.NavItem)
        {
        }

        protected override void PreBuild()
        {
            var link = new Link
            {
                Content = Content,
                Href = Href
            };
            link.AddCss(Css.NavLink);
            if (Active)
                link.AddCss(Css.Active);
            AddChild(link);
            Content = null;
            base.PreBuild();
        }
    }
}