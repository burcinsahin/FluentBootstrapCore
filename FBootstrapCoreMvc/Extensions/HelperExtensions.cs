using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Extensions
{
    public static class HelperExtensions
    {
        public static BootstrapContent<TComponent> VisuallyHidden<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            bool focusable = false) where TComponent : BootstrapComponent
        {
            if (focusable)
                bootstrapContent.Component.AddCss(Css.VisuallyHiddenFocusable);
            else
                bootstrapContent.Component.AddCss(Css.VisuallyHidden);

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> TextBackground<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            TextBgState state = TextBgState.Primary) where TComponent : BootstrapComponent
        {
            bootstrapContent.Component.AddCss(state.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Color<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, LinkColor linkColor)
            where TComponent : BootstrapComponent, ILink
        {
            bootstrapContent.Component.AddCss(linkColor.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Position<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, Fixed @fixed)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Component.AddCss(@fixed.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Position<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, Sticky sticky, Breakpoint br = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Component.AddCss(string.Format(sticky.GetCssDescription(), br.GetHyphenatedDescription()));
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Ratio<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, Ratio ratio)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Component.AddCss(Css.Ratio, ratio.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Ratio<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, byte customValue)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Component.AddCss(Css.Ratio);
            bootstrapContent.Component.MergeStyle("--bs-aspect-ratio", $"{customValue}%");

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Stack<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            Stack stack, Gap gap) where TComponent : BootstrapComponent
        {
            bootstrapContent.Component.AddCss(stack.GetCssDescription());
            bootstrapContent.Gap(gap);

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Stretched<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, bool stretched = true)
            where TComponent : BootstrapComponent, ILink
        {
            bootstrapContent.Component.AddCss(Css.StretchedLink);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Truncate<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, bool truncate = true)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Component.AddCss(Css.TextTruncate);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> VR<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Component.AddCss(Css.Vr);
            return bootstrapContent;
        }
    }
}
