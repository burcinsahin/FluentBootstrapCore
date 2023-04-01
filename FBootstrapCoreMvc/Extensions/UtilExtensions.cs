﻿using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Options;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace FBootstrapCoreMvc.Extensions
{
    public static class UtilExtensions
    {
        public static BootstrapContent<TComponent> Background<TComponent>(this BootstrapContent<TComponent> bootstrapContent, BackgroundColor bgColor, bool gradient = false, byte? opacity = null)
            where TComponent : BootstrapComponent
        {
            bootstrapContent.Component.UtilityOpts.BackgroundOpts = new BackgroundOptions()
            {
                BgColor = bgColor,
                Gradient = gradient,
                Opacity = opacity
            };

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
            bootstrapContent.Component.UtilityOpts.ColorOpts = new ColorOptions()
            {
                TextColor = txtColor,
                Opacity = opacity
            };

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Border<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Border? border = null, BorderColor borderColor = BorderColor.None, BorderRadius? borderRadius = null, byte? opacity = null)
            where TComponent : BootstrapComponent
        {
            if (!borderColor.Equals(BorderColor.None) && border == null)
                border = Enums.Border.All;

            bootstrapContent.Component.UtilityOpts.BorderOpts = new BorderOptions()
            {
                Border = border,
                BorderColor = borderColor,
                BorderRadius = borderRadius,
                Opacity = opacity
            };

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Display<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Display display, Breakpoint br = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            if (bootstrapContent.Component.UtilityOpts.DisplayOpts == null)
                bootstrapContent.Component.UtilityOpts.DisplayOpts = new DisplayOptions();

            bootstrapContent.Component.UtilityOpts.DisplayOpts.Display.TryAdd(br, display);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Display<TComponent>(this BootstrapContent<TComponent> bootstrapContent, DisplayPrint displayPrint)
            where TComponent : BootstrapComponent
        {
            if (bootstrapContent.Component.UtilityOpts.DisplayOpts == null)
                bootstrapContent.Component.UtilityOpts.DisplayOpts = new DisplayOptions();

            bootstrapContent.Component.UtilityOpts.DisplayOpts.DisplayPrint = displayPrint;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Float<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Float @float, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : BootstrapComponent
        {
            if (bootstrapContent.Component.UtilityOpts.FloatOpts == null)
                bootstrapContent.Component.UtilityOpts.FloatOpts = new FloatOptions();

            bootstrapContent.Component.UtilityOpts.FloatOpts.Float.TryAdd(breakpoint, @float);
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
