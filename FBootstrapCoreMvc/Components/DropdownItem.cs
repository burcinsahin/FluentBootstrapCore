using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class DropdownItem : HtmlComponent,
        ILink<DropdownItem>
    {
        private Link _link;
        public DropdownItem(string? text)
            : base("li")
        {
            _link = new Link(text).AddCss(Css.DropdownItem);
            AddChild(_link);
        }

        public DropdownItem SetHref(string? href)
        {
            _link.SetHref(href);
            return this;
        }
    }
}