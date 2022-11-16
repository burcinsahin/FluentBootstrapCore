using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class DropdownItem : Component<DropdownItem>,
        ILink<DropdownItem>
    {
        private Link _link;
        public DropdownItem(IHtmlHelper helper, string? text)
            : base(helper, "li")
        {
            _link = new Link(helper, text).AddCss(Css.DropdownItem);
            _childComponents.Add(_link);
            AppendChildrenToHtml();
        }

        public DropdownItem SetHref(string? href)
        {
            _link.SetHref(href);
            return this;
        }
    }
}