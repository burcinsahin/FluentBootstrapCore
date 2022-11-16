using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FBootstrapCoreMvc.Components
{
    public class Link : Component<Link>
    {
        public Link(IHtmlHelper helper, object? content = null)
            : base(helper, "a")
        {
            SetContent(content);
        }

        internal Link SetRole(string role) => AddAttribute("role", role);

        //public Link SetHref(string href) => AddAttribute("href", href);
    }
}