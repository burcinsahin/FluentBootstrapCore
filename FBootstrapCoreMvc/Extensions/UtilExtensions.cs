using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Options;

namespace FBootstrapCoreMvc.Extensions
{
    public static class UtilExtensions
    {
        public static BootstrapContent<TComponent> Background<TComponent>(this BootstrapContent<TComponent> bootstrapContent, BackgroundColor bgColor, bool gradient = false, byte? opacity = null)
            where TComponent : BootstrapComponent
        {
            var backgroundOpts = bootstrapContent.Component.GetOptions<BackgroundOptions>();
            backgroundOpts.BgColor = bgColor;
            backgroundOpts.Opacity = opacity;
            backgroundOpts.Gradient = gradient;

            return bootstrapContent;
        }

        /// <summary>
        /// Color utilities.
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="bootstrapContent"></param>
        /// <param name="bgColor"></param>
        /// <param name="gradient"></param>
        /// <param name="opacity"></param>
        /// <returns></returns>
        public static BootstrapContent<TComponent> Color<TComponent>(this BootstrapContent<TComponent> bootstrapContent, TextColor txtColor, byte? opacity = null)
            where TComponent : BootstrapComponent
        {
            var colorOpts = bootstrapContent.Component.GetOptions<ColorOptions>();
            colorOpts.TextColor = txtColor;
            colorOpts.Opacity = opacity;

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Border<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Border? border = null, BorderColor borderColor = BorderColor.None, BorderRadius? borderRadius = null, byte? opacity = null)
            where TComponent : BootstrapComponent
        {
            if (!borderColor.Equals(BorderColor.None) && border == null)
                border = Enums.Border.All;

            var borderOpts = bootstrapContent.Component.GetOptions<BorderOptions>();
            borderOpts.Border = border;
            borderOpts.BorderColor = borderColor;
            borderOpts.BorderRadius = borderRadius;
            borderOpts.Opacity = opacity;

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Display<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Display display, Breakpoint br = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var displayOpts = bootstrapContent.Component.GetOptions<DisplayOptions>();
            displayOpts.Display.TryAdd(br, display);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Display<TComponent>(this BootstrapContent<TComponent> bootstrapContent, DisplayPrint displayPrint)
            where TComponent : BootstrapComponent
        {
            var displayOpts = bootstrapContent.Component.GetOptions<DisplayOptions>();
            displayOpts.DisplayPrint = displayPrint;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Flex<TComponent>(this BootstrapContent<TComponent> bootstrapContent, FlexDirection flexDir, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Display(Enums.Display.Flex);

            var flexOpts = bootstrapContent.Component.GetOptions<FlexOptions>();
            flexOpts.Direction.TryAdd(breakpoint, flexDir);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Flex<TComponent>(this BootstrapContent<TComponent> bootstrapContent, JustifyContent justifyContent, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Display(Enums.Display.Flex);

            var flexOpts = bootstrapContent.Component.GetOptions<FlexOptions>();
            flexOpts.JustifyContent.TryAdd(breakpoint, justifyContent);
            return bootstrapContent;
        }
        public static BootstrapContent<TComponent> Float<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Float @float, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var flexOpts = bootstrapContent.Component.GetOptions<FloatOptions>();
            flexOpts.Float.TryAdd(breakpoint, @float);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Overflow<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Overflow overflow = Enums.Overflow.Auto)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(overflow.GetCssDescription());
            return bootstrapContent;
        }

    }
}
