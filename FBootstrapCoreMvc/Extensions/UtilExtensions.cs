using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Options;
using Newtonsoft.Json.Linq;
using System.Globalization;

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

        #region Sizings
        public static BootstrapContent<TComponent> Width<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Width width)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<CommonOptions>();
            options.Width = width;
            return bootstrapContent;
        }
        public static BootstrapContent<TComponent> Height<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Height height)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<CommonOptions>();
            options.Height = height;
            return bootstrapContent;
        }
        #endregion

        #region Spacing
        public static BootstrapContent<TComponent> Margin<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Margin margin, sbyte value = -1, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<SpacingOptions>();
            options.Margin.TryAdd((breakpoint, margin), value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Margin<TComponent>(this BootstrapContent<TComponent> bootstrapContent, sbyte value, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Margin(Enums.Margin.All, value, breakpoint);
            return bootstrapContent;
        }

        /// <summary>
        /// Margin with matrix values
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="bootstrapContent"></param>
        /// <param name="matrix">[top,right,bottom,left] matrix. null for skipping.</param>
        /// <param name="br">breakpoint sm, md, lg etc.</param>
        /// <returns></returns>
        public static BootstrapContent<TComponent> Margin<TComponent>(this BootstrapContent<TComponent> bootstrapContent, sbyte?[] matrix, Breakpoint br = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            if (matrix == null || matrix.Length < 4)
                return bootstrapContent;

            var top = matrix[0];
            var right = matrix[1];
            var bottom = matrix[2];
            var left = matrix[3];

            if (top.HasValue)
            {
                bootstrapContent.Margin(Enums.Margin.Top, top.Value, br);
            }
            if (right.HasValue)
            {
                bootstrapContent.Margin(Enums.Margin.End, right.Value, br);
            }
            if (bottom.HasValue)
            {
                bootstrapContent.Margin(Enums.Margin.Bottom, bottom.Value, br);
            }
            if (left.HasValue)
            {
                bootstrapContent.Margin(Enums.Margin.Start, left.Value, br);
            }
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Padding<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Padding padding, sbyte value = -1, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<SpacingOptions>();
            options.Padding.TryAdd((breakpoint, padding), value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Padding<TComponent>(this BootstrapContent<TComponent> bootstrapContent, sbyte value, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Padding(Enums.Padding.All, value, breakpoint);
            return bootstrapContent;
        }

        /// <summary>
        /// Padding with matrix values
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="bootstrapContent"></param>
        /// <param name="matrix">[top,right,bottom,left] matrix. null for skipping.</param>
        /// <param name="br">breakpoint sm, md, lg etc.</param>
        /// <returns></returns>
        public static BootstrapContent<TComponent> Padding<TComponent>(this BootstrapContent<TComponent> bootstrapContent, sbyte?[] matrix, Breakpoint br = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            if (matrix == null || matrix.Length < 4)
                return bootstrapContent;

            var top = matrix[0];
            var right = matrix[1];
            var bottom = matrix[2];
            var left = matrix[3];

            if (top.HasValue)
            {
                bootstrapContent.Padding(Enums.Padding.Top, top.Value, br);
            }
            if (right.HasValue)
            {
                bootstrapContent.Padding(Enums.Padding.End, right.Value, br);
            }
            if (bottom.HasValue)
            {
                bootstrapContent.Padding(Enums.Padding.Bottom, bottom.Value, br);
            }
            if (left.HasValue)
            {
                bootstrapContent.Padding(Enums.Padding.Start, left.Value, br);
            }
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Gap<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Gap gap, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<SpacingOptions>();
            options.Gap.TryAdd(breakpoint, gap);
            return bootstrapContent;
        }
        #endregion

        #region Text
        public static BootstrapContent<TComponent> AlignText<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            TextAlign textAlign,
            Breakpoint br = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.TextAlign.TryAdd(br, textAlign);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> WrapText<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            TextWrap textWrap = TextWrap.Wrap)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.TextWrap = textWrap;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> TransformText<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            TextTransform textTransform)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.TextTransform = textTransform;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> DecorateText<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            TextDecoration textDecoration)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.TextDecoration = textDecoration;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> FontSize<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            FontSize fontSize)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.FontSize = fontSize;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> FontWeight<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            FontWeight fontWeight)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.FontWeight = fontWeight;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> FontStyle<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            FontStyle fontStyle)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.FontStyle = fontStyle;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> FontMonospace<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            bool monospace = true)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.FontMonospace = monospace;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> ResetText<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            bool reset = true)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.TextReset = reset;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> BreakWord<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.WordBreak = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> LineHeight<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            LineHeight lineHeight)
            where TComponent : BootstrapComponent
        {
            var options = bootstrapContent.Component.GetOptions<TextOptions>();
            options.LineHeight = lineHeight;
            return bootstrapContent;
        }

        #endregion
    }
}