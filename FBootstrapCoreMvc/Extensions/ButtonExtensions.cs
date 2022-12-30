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
            where TComponent : HtmlComponent, ICanHaveIcon
        {
            bootstrapContent.Component.IconType = iconType;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetActive<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool active = true)
            where TComponent : HtmlComponent, IHaveButtonExtensions
        {
            if (active)
                bootstrapContent.Component.AddCss(Css.Active);

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetDisabled<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool disabled = true)
            where TComponent : HtmlComponent, IHaveButtonExtensions
        {
            if (disabled)
                bootstrapContent.Component.AddCss(Css.Disabled);

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetState<TComponent>(this BootstrapContent<TComponent> bootstrapContent, ButtonState buttonState)
            where TComponent : HtmlComponent, IHaveButtonExtensions
        {
            bootstrapContent.Component.ButtonState = buttonState;
            return bootstrapContent;
        }
    }
}
