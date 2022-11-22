﻿using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Components
{
    public class NavbarDropdown : HtmlComponent,
        ICanCreate<DropdownMenu>
    {
        public NavbarDropdown(string text)
            : base("li", Css.NavItem, Css.Dropdown)
        {
            var link = new Link(text);
            link.AddCss(Css.NavLink, Css.DropdownToggle);
            link.SetHref("#");
            link.SetRole("button");
            link.AddAttribute("data-bs-toggle", "dropdown");
            link.AddAttribute("aria-expanded", false);
            AddChild(link);
        }
    }
}