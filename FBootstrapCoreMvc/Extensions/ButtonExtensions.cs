using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Extensions
{
    public static class ButtonExtensions
    {
        public static BootstrapContent<TComponent> SetSize<TComponent>(this BootstrapContent<TComponent> bootstrapContent, ButtonSize size = ButtonSize.Default)
            where TComponent : HtmlComponent, IHaveButtonExtensions
        {
            bootstrapContent.Component.AddCss(size.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetType<TComponent>(this BootstrapContent<TComponent> bootstrapContent, ButtonType type = ButtonType.Button)
            where TComponent : HtmlComponent, IHaveButtonExtensions
        {
            bootstrapContent.Component.MergeAttribute("type", type.GetDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetIcon<TComponent>(this BootstrapContent<TComponent> bootstrapContent, IconType iconType)
            where TComponent : HtmlComponent
        {
            var icon = new Icon(iconType);
            bootstrapContent.Component.AddChild(icon, ChildType.Header);
            return bootstrapContent;
        }

        //public static TComponent SetName<TComponent>(this TComponent component, string name)
        //    where TComponent : Component<TComponent>, IHaveButtonExtensions
        //{
        //    return component.AddAttribute("name", name);
        //}

    }
}
