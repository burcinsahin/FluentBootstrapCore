using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using FluentBootstrapCore.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace FluentBootstrapCore.Extensions
{
    public static class InterfaceExtensions
    {
        public static BootstrapContent<TComponent> Disabled<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            bool value = true)
            where TComponent : SingleComponent, ICanBeDisabled
        {
            bootstrapContent.Component.Disabled = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Value<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            object value)
            where TComponent : SingleComponent, ICanHaveValue
        {
            bootstrapContent.Component.Value = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Name<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string? name)
            where TComponent : SingleComponent, ICanHaveName
        {
            bootstrapContent.Component.Name = name;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> WithBadge<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            object? content, string? hiddenMessage = null, params IUtilityOptions[] options)
            where TComponent : BootstrapComponent, ICanHaveBadge
        {
            var badge = new Badge() { Content = content };
            foreach (var opts in options)
            {
                badge.UtilityOptions.Add(opts);
            }
            if (hiddenMessage != null)
            {
                var span = new HtmlElement("span") { Content = hiddenMessage };
                span.AddCss(Css.VisuallyHidden);
                badge.AddChild(span);
            }
            bootstrapContent.Component.Badge = badge;

            return bootstrapContent;
        }

        //public static BootstrapContent<TComponent> BadgeOpts<TComponent>(
        //    this BootstrapContent<TComponent> bootstrapContent,
        //    IUtilityOptions opts)
        //    where TComponent : Button, ICanHaveBadge
        //{
        //    bootstrapContent.Component.Badge?.UtilityOptions.AddOrUpdate(opts);
        //    return bootstrapContent;
        //}

        public static BootstrapContent<TComponent> PositionBadge<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : BootstrapComponent, ICanHaveBadge
        {
            if (bootstrapContent.Component.Badge == null)
                return bootstrapContent;

            var badge = bootstrapContent.Component.Badge;

            badge.UtilityOptions.Add(new PositionOptions
            {
                Position = Position.Absolute,
                Absolute = Absolute.Top0 | Absolute.Start100,
                Translate = Translate.Middle
            });

            badge.UtilityOptions.Add(new BackgroundOptions
            {
                BgColor = BgColor.Danger
            });

            if (badge.Content is string badgeContent && badgeContent.Equals(string.Empty))
            {
                badge.UtilityOptions.Add(new BorderOptions
                {
                    Border = Border.All,
                    BorderRadius = BorderRadius.RoundedCircle,
                    BorderColor = BorderColor.Light
                });
                var badgeSpacingOpts = new SpacingOptions();
                badgeSpacingOpts.Padding.Add((Breakpoint.Default, Padding.All), 2);
                badge.UtilityOptions.Add(badgeSpacingOpts);
                //badge.Content = " ";
            }
            else
                badge.UtilityOptions.Add(new BorderOptions { BorderRadius = BorderRadius.RoundedPill });

            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Active<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, bool value = true)
            where TComponent : SingleComponent, ICanBeActive
        {
            bootstrapContent.Component.Active = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Href<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string href = "#")
            where TComponent : SingleComponent, ILink
        {
            bootstrapContent.Component.Href = href;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Href<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string action,
            string controller,
            object? routeValues = null)
            where TComponent : SingleComponent, ILink
        {
            bootstrapContent.Component.Href = bootstrapContent.HtmlHelper.GetUrlHelper().Action(action, controller, routeValues);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Target<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            LinkTarget target) where TComponent : SingleComponent, ILink
        {
            bootstrapContent.Component.Target = target;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> JustifyContent<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, JustifyContent justifyContent, Breakpoint br = Breakpoint.Default)
            where TComponent : SingleComponent, IJustifyContent
        {
            if (bootstrapContent.Component.JustifyContent == null)
                bootstrapContent.Component.JustifyContent = new EnumList<JustifyContent>();

            bootstrapContent.Component.JustifyContent.TryAdd(br, justifyContent);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Options<TComponent>(this BootstrapContent<TComponent> bootstrapContent,
            IEnumerable<SelectListItem> list)
            where TComponent : SingleComponent, ICanHaveOptions
        {
            bootstrapContent.Component.SelectList = list;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Size<TComponent, TEnum>(
            this BootstrapContent<TComponent> bootstrapContent,
            TEnum size) 
            where TComponent : BootstrapComponent, ISizable<TEnum> 
            where TEnum : struct, Enum
        {
            bootstrapContent.Component.Size = size;
            return bootstrapContent;
        }
    }
}
