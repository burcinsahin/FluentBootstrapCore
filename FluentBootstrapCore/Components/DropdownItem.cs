using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class DropdownItem : BootstrapComponent,
        ILink
    {
        public string? Href { get; set; }
        public LinkTarget? Target { get; set; }

        public DropdownItem()
            : base("li")
        {
        }

        protected override void PreBuild()
        {
            var link = new Link
            {
                Content = Content,
                Href = Href
            };
            link.AddCss(Css.DropdownItem);
            AddChild(link);
            Content = null;
            base.PreBuild();
        }
    }
}