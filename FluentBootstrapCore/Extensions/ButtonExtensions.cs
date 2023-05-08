using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Extensions
{
    public static class ButtonExtensions
    {
        public static BootstrapContent<Button> Button<TComponent>(this ComponentBuilder<TComponent> builder, object? content = null)
            where TComponent : BootstrapComponent, ICanCreate<Button>
        {
            var button = new Button
            {
                Content = content
            };
            return new BootstrapContent<Button>(builder.HtmlHelper, button);
        }

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

        public static BootstrapContent<TComponent> Modal<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string modalId)
            where TComponent : SingleComponent, IButton
        {
            if(!modalId.StartsWith("#"))
                modalId = $"#{modalId}";
            bootstrapContent.Component.MergeAttribute("data-bs-target", $"{modalId}");
            bootstrapContent.Component.MergeAttribute("data-bs-toggle", $"modal");
            return bootstrapContent;
        }

    }
}
