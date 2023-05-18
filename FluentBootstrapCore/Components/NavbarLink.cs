using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class NavbarLink : BootstrapComponent,
        ILink,
        ICanBeActive,
        ICanBeDisabled
    {
        public string? Href { get; set; }
        public bool Active { get; set; }
        public LinkTarget? Target { get; set; }
        public bool Disabled { get; set; }

        public NavbarLink()
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

            if (Disabled)
                link.AddCss(Css.Disabled);

            Content = link;
            base.PreBuild();
        }
    }
}