using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Html;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace FBootstrapCoreMvc.Extensions
{
    public static class ComponentExtensions
    {
        #region Common
        public static Component AddCss(this Component component, params string[] cssClasses)
        {
            foreach (var css in cssClasses)
            {
                component.AddCssClass(css);
            }
            return component;
        }

        public static TComponent SetId<TComponent>(this TComponent component, string? id = null)
            where TComponent : Component<TComponent>
        {
            if (id == null)
                id = $"{typeof(TComponent).Name}_{DateTime.Now.Ticks}";

            component.MergeAttribute("id", id);
            return component;
        }

        public static TComponent SetContent<TComponent>(this TComponent component, object? content)
            where TComponent : Component<TComponent>
        {
            if (content == null)
                return component;

            if (content is IHtmlContent htmlContent)
            {
                component.InnerHtml.SetHtmlContent(htmlContent);
                return component;
            }
            component.InnerHtml.SetContent(content.ToString());
            return component;
        }

        public static TComponent AddCss<TComponent>(this TComponent component, params string[] cssClasses)
            where TComponent : Component<TComponent>
        {
            foreach (var css in cssClasses)
            {
                component.AddCssClass(css);
            }
            return component;
        }

        public static TComponent AddStyle<TComponent>(this TComponent component, string name, string value)
            where TComponent : Component<TComponent>
        {
            component.MergeAttribute("style", $"{name}:{value}", false);
            return component;
        }

        public static TComponent AddStyles<TComponent>(this TComponent component, object styles)
            where TComponent : Component<TComponent>
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(styles))
            {
                var key = property.Name;
                var value = Convert.ToString(property.GetValue(styles), CultureInfo.InvariantCulture);
                component.AddStyle(key, value);
            }
            return component;
        }
        #endregion

        #region Interface Filtered
        public static TComponent SetValue<TComponent>(this TComponent component, object? value)
            where TComponent : Component<TComponent>, ICanHaveValue
        {
            if (value == null)
                return component;

            component.AddAttribute("value", value);
            return component;
        }

        public static TComponent SetName<TComponent>(this TComponent component, string? name)
            where TComponent : Component<TComponent>, ICanHaveName
        {
            return component.AddAttribute("name", name);
        }

        public static TComponent SetDisabled<TComponent>(this TComponent component, bool? value = true)
            where TComponent : Component<TComponent>, ICanBeDisabled
        {
            if (value == null || value == false)
                return component;
            return component.AddAttribute("disabled", "");
        }
        #endregion

    }
}
