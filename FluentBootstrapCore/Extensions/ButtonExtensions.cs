using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using System;

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

        //public static BootstrapContent<TComponent> Disabled<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool disabled = true)
        //    where TComponent : SingleComponent, IButton
        //{
        //    if (disabled)
        //        bootstrapContent.Component.AddCss(Css.Disabled);

        //    return bootstrapContent;
        //}

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
            where TComponent : BootstrapComponent, IButton
        {
            if (!modalId.StartsWith("#"))
                modalId = $"#{modalId}";
            if (typeof(ILink).IsAssignableFrom(typeof(TComponent)))
            {
                ((ILink)bootstrapContent.Component).Href = modalId;
            }
            else
                bootstrapContent.Component.MergeAttribute("data-bs-target", modalId);
            bootstrapContent.Component.MergeAttribute("data-bs-toggle", $"modal");
            return bootstrapContent;
        }

        [Obsolete]
        public static BootstrapContent<TComponent> Popover<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string title,
            string content,
            bool dismissable = false)
            where TComponent : BootstrapComponent, IButton
        {
            bootstrapContent.Component.MergeAttribute("data-bs-toggle", "popover");
            bootstrapContent.Component.MergeAttribute("data-bs-title", title);
            bootstrapContent.Component.MergeAttribute("data-bs-content", content);
            bootstrapContent.Component.MergeAttribute("tabindex", 0);
            if (dismissable)
                bootstrapContent.Component.MergeAttribute("data-bs-trigger", "focus");
            return bootstrapContent;
        }


        public static BootstrapContent<TComponent> Tooltip<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string tooltip,
            PopperDirection? direction = null,
            string? customClass = null,
            bool isHtml = false)
            where TComponent : Button
        {
            bootstrapContent.Component.MergeAttribute("data-bs-toggle", "tooltip");
            bootstrapContent.Component.MergeAttribute("title", tooltip);
            if (direction.HasValue)
                bootstrapContent.Component.MergeAttribute("data-bs-placement", direction.GetDescription());
            if (customClass != null)
                bootstrapContent.Component.MergeAttribute("data-bs-custom-class", customClass);
            if (isHtml)
                bootstrapContent.Component.MergeAttribute("data-bs-html", "true");

            return bootstrapContent;
        }
    }
}
