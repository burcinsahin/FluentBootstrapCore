using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FluentBootstrapCore.Extensions
{
    public static class NavbarExtensions
    {
        public static BootstrapContent<TComponent> Dark<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : Navbar
        {
            bootstrapContent.Component.AddCss(Css.NavbarDark);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Expand<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Breakpoint br = Breakpoint.Default)
            where TComponent : Navbar
        {
            bootstrapContent.Component.Expand = br;
            return bootstrapContent;
        }

        public static BootstrapContent<NavbarBrand> Brand<TComponent>(this ComponentBuilder<TComponent> builder, object? text)
            where TComponent : BootstrapComponent, ICanCreate<NavbarBrand>
        {
            var brand = new NavbarBrand(text);
            return new BootstrapContent<NavbarBrand>(builder.HtmlHelper, brand);
        }

        public static BootstrapContent<NavbarToggler> NavbarToggler<TComponent>(this ComponentBuilder<TComponent> builder, string? collapseId)
            where TComponent : BootstrapComponent, ICanCreate<NavbarToggler>
        {
            var toggler = new NavbarToggler(collapseId);
            return new BootstrapContent<NavbarToggler>(builder.HtmlHelper, toggler);
        }

        public static BootstrapContent<NavbarCollapse> NavbarCollapse<TComponent>(this ComponentBuilder<TComponent> builder, string? id)
            where TComponent : BootstrapComponent, ICanCreate<NavbarCollapse>
        {
            var navbarCollapse = new NavbarCollapse
            {
                Id = id
            };
            return new BootstrapContent<NavbarCollapse>(builder.HtmlHelper, navbarCollapse);
        }

        public static BootstrapContent<NavbarNav> NavbarNav<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : BootstrapComponent, ICanCreate<NavbarNav>
        {
            var navbarNav = new NavbarNav();
            return new BootstrapContent<NavbarNav>(builder.HtmlHelper, navbarNav);
        }

        public static BootstrapContent<NavbarLink> NavbarLink<TComponent>(this ComponentBuilder<TComponent> builder, object? content = null)
            where TComponent : BootstrapComponent, ICanCreate<NavbarLink>
        {
            var navbarLink = new NavbarLink()
            {
                Content = content,
            };
            return new BootstrapContent<NavbarLink>(builder.HtmlHelper, navbarLink);
        }
    }
}
