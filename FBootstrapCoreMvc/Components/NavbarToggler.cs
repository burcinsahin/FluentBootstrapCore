using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarToggler : Component<NavbarToggler>
    {
        public NavbarToggler(IHtmlHelper helper, string? collapseId)
            : base(helper, "button", Css.NavbarToggler)
        {
            AddAttribute("type", "button");
            AddAttribute("data-bs-toggle", "collapse");
            AddAttribute("data-bs-target", $"#{collapseId}");
            AddAttribute("aria-controls", collapseId);
            AddAttribute("aria-expanded", false);
            AddAttribute("aria-label", "Toggle");
        }
    }
}