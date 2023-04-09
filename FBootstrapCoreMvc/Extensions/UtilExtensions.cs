using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Options;

namespace FBootstrapCoreMvc.Extensions
{
    public static class UtilExtensions
    {
        public static BootstrapContent<TComponent> Background<TComponent>(this BootstrapContent<TComponent> bootstrapContent, BgColor bgColor, bool gradient = false, byte? opacity = null)
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

        public static BootstrapContent<TComponent> Flex<TComponent>(this BootstrapContent<TComponent> bootstrapContent, AlignItems alignItems, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Display(Enums.Display.Flex);

            var flexOpts = bootstrapContent.Component.GetOptions<FlexOptions>();
            flexOpts.AlignItems.TryAdd(breakpoint, alignItems);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Flex<TComponent>(this BootstrapContent<TComponent> bootstrapContent, AlignSelf alignSelf, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var flexOpts = bootstrapContent.Component.GetOptions<FlexOptions>();
            flexOpts.AlignSelf.TryAdd(breakpoint, alignSelf);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Flex<TComponent>(this BootstrapContent<TComponent> bootstrapContent, FlexAbility flexFill, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var flexOpts = bootstrapContent.Component.GetOptions<FlexOptions>();
            flexOpts.FlexFill.TryAdd(breakpoint, flexFill);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Float<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Float @float, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var flexOpts = bootstrapContent.Component.GetOptions<FloatOptions>();
            flexOpts.Float.TryAdd(breakpoint, @float);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Order<TComponent>(this BootstrapContent<TComponent> bootstrapContent, sbyte order, Breakpoint br = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            return bootstrapContent.Order((Order)order.Limit<sbyte>(-1, 6), br);
        }

        public static BootstrapContent<TComponent> Order<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Order order, Breakpoint br = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<CommonOptions>();
            options.Order.TryAdd(br, order);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Opacity<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Opacity opacity)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<CommonOptions>();
            options.Opacity = opacity;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AlignContent<TComponent>(this BootstrapContent<TComponent> bootstrapContent, AlignContent alignContent, Breakpoint br = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<FlexOptions>();
            options.AlignContent.TryAdd(br, alignContent);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Overflow<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Overflow overflow = Enums.Overflow.Auto)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(overflow.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> UserSelect<TComponent>(this BootstrapContent<TComponent> bootstrapContent, UserSelect userSelect)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<InteractionOptions>();
            options.UserSelect = userSelect;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> PointerEvent<TComponent>(this BootstrapContent<TComponent> bootstrapContent, PointerEvent pointerEvent)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<InteractionOptions>();
            options.PointerEvent = pointerEvent;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Position<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Position position)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<PositionOptions>();
            options.Position = position;
            return bootstrapContent;
        }
        public static BootstrapContent<TComponent> Position<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Absolute absolutePos, Translate? translate = null)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Position(Enums.Position.Absolute);
            var options = bootstrapContent.Component.GetOptions<PositionOptions>();
            options.Absolute = absolutePos;
            options.Translate = translate;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Shadow<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Shadow shadow = Enums.Shadow.Medium)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<CommonOptions>();
            options.Shadow = shadow;
            return bootstrapContent;
        }
    }
}
