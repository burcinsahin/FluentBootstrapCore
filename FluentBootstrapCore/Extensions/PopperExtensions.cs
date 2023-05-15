using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using Newtonsoft.Json.Linq;
using System;

namespace FluentBootstrapCore.Extensions
{
    /// <summary>
    /// Popover and Tooltip (popper.js) extensions
    /// </summary>
    public static class PopperExtensions
    {
        public static CompositeContent<TComponent> Content<TComponent>(
            this CompositeContent<TComponent> content,
            object? value) where TComponent : Popover
        {
            content.Component.Content = value;
            return content;
        }

        public static CompositeContent<TComponent> Container<TComponent>(
            this CompositeContent<TComponent> content,
            string value) where TComponent : HtmlComponent, IPopover
        {
            content.Component.Container = value;
            return content;
        }

        public static CompositeContent<TComponent> Direction<TComponent>(
            this CompositeContent<TComponent> content,
            PopoverDirection direction) where TComponent : HtmlComponent, IPopover
        {
            content.Component.Direction = direction;
            return content;
        }

        public static CompositeContent<TComponent> State<TComponent>(
            this CompositeContent<TComponent> content,
            ButtonState state) where TComponent : HtmlComponent, IPopover
        {
            content.Component.State = state;
            return content;
        }

        public static CompositeContent<TComponent> CustomClass<TComponent>(
            this CompositeContent<TComponent> content,
            string cssClass) where TComponent : HtmlComponent, IPopover
        {
            content.Component.CustomClass = cssClass;
            return content;
        }

        public static CompositeContent<TComponent> Dismissable<TComponent>(
            this CompositeContent<TComponent> content,
            bool value = true) where TComponent : HtmlComponent, IPopover
        {
            content.Component.Dismissable = value;
            return content;
        }

        //TODO: move to compositecontent extensions later
        public static CompositeContent<TComponent> Sized<TComponent, TEnum>(
            this CompositeContent<TComponent> content,
            TEnum size) 
            where TComponent : HtmlComponent, ISizable<TEnum>
            where TEnum : struct, Enum
        {
            content.Component.Size = size;
            return content;
        }
    }
}
