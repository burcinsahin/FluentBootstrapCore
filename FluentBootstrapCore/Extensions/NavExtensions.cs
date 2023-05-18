using FluentBootstrapCore.Components;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Extensions
{
    public static class NavExtensions
    {
        public static BootstrapContent<TComponent> Tabs<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : BootstrapComponent, INav
        {
            //TODO: Move Tabs, Pills etc. to INav as properties
            bootstrapContent.Component.AddCss(Css.NavTabs);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Pills<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : BootstrapComponent, INav
        {
            bootstrapContent.Component.AddCss(Css.NavPills);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Fill<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : BootstrapComponent, INav
        {
            bootstrapContent.Component.AddCss(Css.NavFill);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Justified<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : BootstrapComponent, INav
        {
            bootstrapContent.Component.AddCss(Css.NavJustified);
            return bootstrapContent;
        }

        public static BootstrapContent<NavItem> ListItem<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : BootstrapComponent, INav, ICanCreate<NavItem>
        {
            var navItem = new NavItem();
            return new BootstrapContent<NavItem>(builder.HtmlHelper, navItem);
        }

        public static BootstrapContent<NavLink> Link<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : Nav
        {
            var link = new NavLink();
            return new BootstrapContent<NavLink>(builder.HtmlHelper, link);
        }

        public static BootstrapContent<ListItem> Divider<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : DropdownMenu
        {
            var li = new ListItem()
            {
                Content = new HtmlElement("hr", Css.DropdownDivider)
            };
            return new BootstrapContent<ListItem>(builder.HtmlHelper, li);
        }

        public static BootstrapContent<NavDropdown> Dropdown<TComponent>(this ComponentBuilder<TComponent> builder, string text)
            where TComponent : BootstrapComponent, ICanCreate<NavDropdown>
        {
            var dropdown = new NavDropdown(text);
            return new BootstrapContent<NavDropdown>(builder.HtmlHelper, dropdown);
        }
    }
}
