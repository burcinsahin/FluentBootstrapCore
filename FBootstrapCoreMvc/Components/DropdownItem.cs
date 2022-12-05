using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class DropdownItem : HtmlComponent,
        ILink<DropdownItem>
    {
        private Link _link;
        public DropdownItem(string? text)
            : base("li")
        {
            _link = new Link(text);
            _link.AddCss(Css.DropdownItem);
            AddChild(_link);
        }

        public DropdownItem SetHref(string? href)
        {
            _link.SetHref(href);
            return this;
        }
    }
}