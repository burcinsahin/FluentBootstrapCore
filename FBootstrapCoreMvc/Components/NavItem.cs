using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class NavItem : BootstrapComponent,
        ICanBeActive,
        ICanBeDisabled,
        ILink
    {
        public bool Active { get; set; }
        public string? Href { get; set; }
        public bool Disabled { get; set; }

        public NavItem() : base("li", Css.NavItem)
        {
        }

        protected override void PreBuild()
        {
            if (Href != null)
            {
                var link = new Link() { Content = Content, Href = Href };
                link.AddCss(Css.NavLink);
                if (Active) link.AddCss(Css.Active);
                if (Disabled) link.AddCss(Css.Disabled);
                Content = link;
            }

            base.PreBuild();
        }
    }
}
