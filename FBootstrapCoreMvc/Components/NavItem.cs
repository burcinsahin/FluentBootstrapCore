using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class NavItem : BootstrapComponent, ICanBeActive, ILink
    {
        public bool Active { get; set; }
        public string? Href { get; set; }

        public NavItem() : base("li", Css.NavItem)
        {
        }
    }
}
