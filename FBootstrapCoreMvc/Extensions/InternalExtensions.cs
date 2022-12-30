using FBootstrapCoreMvc.Interfaces;
using System;

namespace FBootstrapCoreMvc.Extensions
{
    /// <summary>
    /// Internal HtmlComponent extension methods
    /// </summary>
    internal static class InternalExtensions
    {
        /// <summary>
        /// Sets id with given value. If no value given then generates a random value as id.
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="component"></param>
        /// <param name="id">optional</param>
        /// <returns></returns>
        internal static TComponent SetId<TComponent>(this TComponent component, string? id = null)
            where TComponent : HtmlComponent
        {
            if (id == null)
                id = $"{component.Tag}_{DateTime.Now.Ticks}";
            component.Id = id;
            return component;
        }

        internal static TComponent SetContent<TComponent>(this TComponent component, object? content)
            where TComponent : HtmlComponent
        {
            component.Content = content;
            return component;
        }

        internal static TComponent SetDisabled<TComponent>(this TComponent component, bool value = true)
            where TComponent : HtmlComponent, ICanBeDisabled
        {
            component.Disabled = value;
            return component;
        }

        internal static TComponent SetValue<TComponent>(this TComponent component, object? value = null)
            where TComponent : HtmlComponent, ICanHaveValue
        {
            if (value != null)
                component.MergeAttribute("value", value, true);
            return component;
        }

        internal static TComponent SetName<TComponent>(this TComponent component, string? name)
            where TComponent : HtmlComponent, ICanHaveName
        {
            component.MergeAttribute("name", name);
            return component;
        }
    }
}
