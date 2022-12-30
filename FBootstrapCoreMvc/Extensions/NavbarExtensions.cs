using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FBootstrapCoreMvc.Extensions
{
    public static class NavbarExtensions
    {
        public static BootstrapContent<TComponent> SetHref<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string? href)
            where TComponent : Link
        {
            bootstrapContent.Component.MergeAttribute("href", href);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetDark<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : Navbar
        {
            bootstrapContent.Component.AddCss(Css.NavbarDark);
            return bootstrapContent;
        }

        public static BootstrapContent<NavbarBrand> Brand<TComponent>(this BootstrapBuilder<TComponent> builder, object? text)
            where TComponent : HtmlComponent, ICanCreate<NavbarBrand>
        {
            var brand = new NavbarBrand(text);
            return new BootstrapContent<NavbarBrand>(builder.HtmlHelper, brand);
        }

        public static BootstrapContent<NavbarToggler> NavbarToggler<TComponent>(this BootstrapBuilder<TComponent> builder, string? collapseId)
            where TComponent : HtmlComponent, ICanCreate<NavbarToggler>
        {
            var toggler = new NavbarToggler(collapseId);
            return new BootstrapContent<NavbarToggler>(builder.HtmlHelper, toggler);
        }

        public static BootstrapContent<NavbarCollapse> NavbarCollapse<TComponent>(this BootstrapBuilder<TComponent> builder, string? id)
            where TComponent : HtmlComponent, ICanCreate<NavbarCollapse>
        {
            var navbarCollapse = new NavbarCollapse();
            navbarCollapse.SetId(id);
            return new BootstrapContent<NavbarCollapse>(builder.HtmlHelper, navbarCollapse);
        }

        public static BootstrapContent<NavbarNav> NavbarNav<TComponent>(this BootstrapBuilder<TComponent> builder)
            where TComponent : HtmlComponent, ICanCreate<NavbarNav>
        {
            var navbarNav = new NavbarNav();
            return new BootstrapContent<NavbarNav>(builder.HtmlHelper, navbarNav);
        }

        public static BootstrapContent<NavbarLink> NavbarLink<TComponent>(this BootstrapBuilder<TComponent> builder, string text, string action, string controller, object? routeValues = null)
            where TComponent : HtmlComponent, ICanCreate<NavbarLink>
        {
            var navbarLink = new NavbarLink(text);
            navbarLink.SetHref(builder.HtmlHelper.GetUrlHelper().Action(action, controller, routeValues));
            return new BootstrapContent<NavbarLink>(builder.HtmlHelper, navbarLink);

        }

        public static BootstrapContent<NavbarDropdown> Dropdown<TComponent>(this BootstrapBuilder<TComponent> builder, string text)
            where TComponent : HtmlComponent, ICanCreate<NavbarDropdown>
        {
            var dropdown = new NavbarDropdown(text);
            return new BootstrapContent<NavbarDropdown>(builder.HtmlHelper, dropdown);
        }
    }
}
