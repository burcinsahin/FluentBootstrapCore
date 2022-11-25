using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using System;

namespace FBootstrapCoreMvc.Extensions
{
    public static class ComponentExtensions
    {
        #region Internals
        //public static Component AddCss(this Component component, params string[] cssClasses)
        //{
        //    foreach (var css in cssClasses)
        //    {
        //        component.AddCssClass(css);
        //    }
        //    return component;
        //}



        //internal static TComponent AddCss<TComponent>(this TComponent component, params string[] cssClasses)
        //    where TComponent : HtmlComponent
        //{
        //    foreach (var css in cssClasses)
        //    {
        //        component.AddCss(cssclas);
        //    }
        //    return component;
        //}

        //public static TComponent AddStyle<TComponent>(this TComponent component, string name, string value)
        //    where TComponent : Component<TComponent>
        //{
        //    component.MergeAttribute("style", $"{name}:{value}", false);
        //    return component;
        //}

        //public static TComponent AddStyles<TComponent>(this TComponent component, object styles)
        //    where TComponent : Component<TComponent>
        //{
        //    foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(styles))
        //    {
        //        var key = property.Name;
        //        var value = Convert.ToString(property.GetValue(styles), CultureInfo.InvariantCulture);
        //        component.AddStyle(key, value);
        //    }
        //    return component;
        //}

        public static BootstrapContent<TComponent> SetTextBgState<TComponent>(this BootstrapContent<TComponent> bootstrapContent, TextBgState state = TextBgState.Primary)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.AddCss(state.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetBgState<TComponent>(this BootstrapContent<TComponent> bootstrapContent, BackgroundState state = BackgroundState.Primary)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.AddCss(state.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetId<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string? id = null)
            where TComponent : HtmlComponent
        {
            if (id == null)
                id = $"{typeof(TComponent).Name}_{DateTime.Now.Ticks}";
            bootstrapContent.Component.Id = id;
            return bootstrapContent;
        }
        #endregion

        #region Interface Filtered
        public static BootstrapContent<TComponent> SetValue<TComponent>(this BootstrapContent<TComponent> bootstrapContent, object? value)
            where TComponent : HtmlComponent, ICanHaveValue
        {
            if (value == null)
                return bootstrapContent;

            bootstrapContent.Component.MergeAttribute("value", value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetName<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string? name)
            where TComponent : HtmlComponent, ICanHaveName
        {
            bootstrapContent.Component.MergeAttribute("name", name);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetDisabled<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool? value = true)
            where TComponent : HtmlComponent, ICanBeDisabled
        {
            if (value.HasValue && value == false)
                return bootstrapContent;
            bootstrapContent.Component.MergeAttribute("disabled");
            return bootstrapContent;
        }
        #endregion
    }
}
