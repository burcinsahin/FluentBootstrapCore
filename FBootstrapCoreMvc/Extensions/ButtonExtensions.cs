using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Extensions
{
    public static class ButtonExtensions
    {
        public static BootstrapContent<TComponent> Size<TComponent>(this BootstrapContent<TComponent> bootstrapContent, ButtonSize size = ButtonSize.Default)
            where TComponent : SingleComponent, IButton
        {
            bootstrapContent.Component.AddCss(size.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Type<TComponent>(this BootstrapContent<TComponent> bootstrapContent, ButtonType type = ButtonType.Button)
            where TComponent : BootstrapComponent, IButton
        {
            bootstrapContent.Component.ButtonType = type;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Icon<TComponent>(this BootstrapContent<TComponent> bootstrapContent, IconType iconType)
            where TComponent : SingleComponent, ICanHaveIcon
        {
            bootstrapContent.Component.IconType = iconType;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Toggle<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool toggle = true)
            where TComponent : ButtonComponent, IButton
        {
            if (toggle)
                bootstrapContent.Component.MergeAttribute("data-bs-toggle", "button", true);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Disabled<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool disabled = true)
            where TComponent : SingleComponent, IButton
        {
            if (disabled)
                bootstrapContent.Component.AddCss(Css.Disabled);

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> State<TComponent>(this BootstrapContent<TComponent> bootstrapContent, ButtonState buttonState)
            where TComponent : BootstrapComponent, IButton
        {
            bootstrapContent.Component.ButtonState = buttonState;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Outline<TComponent>(this BootstrapContent<TComponent> bootstrapContent, ButtonOutlineState outline, ButtonState state = ButtonState.None)
            where TComponent : BootstrapComponent, IButton
        {
            bootstrapContent.Component.OutlineState = outline;
            bootstrapContent.Component.ButtonState = state;

            return bootstrapContent;
        }

    }
}
