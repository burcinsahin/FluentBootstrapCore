using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FBootstrapCoreMvc.Components
{
    public class Link : HtmlComponent
    {
        public Link(object? content = null)
            : base("a")
        {
            AppendContent(content);
        }

        internal void SetRole(string role) => AddAttribute("role", role);

        //public Link SetHref(string href) => AddAttribute("href", href);
    }
}