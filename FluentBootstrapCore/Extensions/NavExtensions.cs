using FluentBootstrapCore.Components;

namespace FluentBootstrapCore.Extensions
{
    public static class NavExtensions
    {
        public static BootstrapContent<TComponent> Tabs<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : Nav
        {
            bootstrapContent.Component.AddCss(Css.NavTabs);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Pills<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : Nav
        {
            bootstrapContent.Component.AddCss(Css.NavPills);
            return bootstrapContent;
        }

        public static BootstrapContent<NavItem> NavItem<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : Nav
        {
            var navItem = new NavItem();
            return new BootstrapContent<NavItem>(builder.HtmlHelper, navItem);
        }
    }
}
