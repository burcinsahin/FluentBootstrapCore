using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FBootstrapCoreMvc.Extensions
{
    public static class NavbarExtensions
    {
        public static TComponent SetHref<TComponent>(this TComponent component, string? href)
            where TComponent : Link
        {
            component.AddAttribute("href", href);
            return component;
        }

        public static NavbarBrand Brand<TComponent>(this HtmlBuilder<TComponent> builder, string? text)
            where TComponent : Component<TComponent>, ICanCreate<NavbarBrand>
        {
            var brand = new NavbarBrand(builder.HtmlHelper, text);
            return brand;
        }

        public static NavbarToggler NavbarToggler<TComponent>(this HtmlBuilder<TComponent> builder, string? collapseId)
            where TComponent : Component<TComponent>, ICanCreate<NavbarToggler>
        {
            var brand = new NavbarToggler(builder.HtmlHelper, collapseId);
            return brand;
        }

        public static NavbarCollapse NavbarCollapse<TComponent>(this HtmlBuilder<TComponent> builder, string? id)
            where TComponent : Component<TComponent>, ICanCreate<NavbarCollapse>
        {
            var navbarCollapse = new NavbarCollapse(builder.HtmlHelper, id);
            return navbarCollapse;
        }

        public static NavbarNav NavbarNav<TComponent>(this HtmlBuilder<TComponent> builder)
            where TComponent : Component<TComponent>, ICanCreate<NavbarNav>
        {
            var navbarNav = new NavbarNav(builder.HtmlHelper);
            return navbarNav;
        }

        public static NavbarLink NavbarLink<TComponent>(this HtmlBuilder<TComponent> builder, string text, string action, string controller, object? routeValues = null)
            where TComponent : Component<TComponent>, ICanCreate<NavbarLink>
        {
            var navbarNav = new NavbarLink(builder.HtmlHelper, text);
            navbarNav.SetHref(builder.HtmlHelper.GetUrlHelper().Action(action, controller, routeValues));
            return navbarNav;
        }

        public static NavbarDropdown Dropdown<TComponent>(this HtmlBuilder<TComponent> builder, string text)
            where TComponent : Component<TComponent>, ICanCreate<NavbarDropdown>
        {
            var dropdown = new NavbarDropdown(builder.HtmlHelper, text);
            return dropdown;
        }
    }
}
