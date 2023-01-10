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
            where TComponent : SingleComponent, IButton
        {
            bootstrapContent.Component.MergeAttribute("type", type.GetDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AddIcon<TComponent>(this BootstrapContent<TComponent> bootstrapContent, IconType iconType)
            where TComponent : SingleComponent, ICanHaveIcon
        {
            bootstrapContent.Component.IconType = iconType;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Active<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool active = true)
            where TComponent : SingleComponent, IButton
        {
            if (active)
                bootstrapContent.Component.AddCss(Css.Active);

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
            where TComponent : SingleComponent, IButton
        {
            bootstrapContent.Component.ButtonState = buttonState;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Outline<TComponent>(this BootstrapContent<TComponent> bootstrapContent, ButtonOutlineState state)
            where TComponent : SingleComponent, IButton
        {
            bootstrapContent.Component.OutlineState = state;
            return bootstrapContent;
        }

    }
}
