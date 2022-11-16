using FBootstrapCoreMvc;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarLink : Component<NavbarLink>
    {
        private Link _link;

        public NavbarLink(IHtmlHelper helper, string? text)
            : base(helper, "li", Css.NavItem)
        {
            _link = new Link(helper, text);
            _link.AddCssClass(Css.NavLink);
            InnerHtml.SetHtmlContent(_link);
        }

        public NavbarLink SetActive()
        {
            _link.AddCssClass(Css.Active);
            _link.AddAttribute("aria-current", "page");
            InnerHtml.SetHtmlContent(_link);
            return this;
        }

        public NavbarLink SetHref(string href)
        {
            _link.AddAttribute("href", href);
            InnerHtml.SetHtmlContent(_link);
            return this;
        }
    }
}