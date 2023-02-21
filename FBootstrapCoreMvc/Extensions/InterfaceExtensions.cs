﻿using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Extensions
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
            string value)
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

        public static BootstrapContent<TComponent> AddBadge<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string? badge)
            where TComponent : SingleComponent, ICanHaveBadge
        {
            bootstrapContent.Component.Badge = badge;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> PositionBadge<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanPositionBadge
        {
            bootstrapContent.Component.PositionBadge = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Active<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeActive
        {
            bootstrapContent.Component.Active = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Href<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, string href = "#")
            where TComponent : SingleComponent, ILink
        {
            bootstrapContent.Component.Href = href;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> JustifyContent<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, JustifyContent justifyContent)
            where TComponent : SingleComponent, IJustifyContent
        {
            bootstrapContent.Component.JustifyContent = justifyContent;
            return bootstrapContent;
        }
    }
}