using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using System;

namespace FBootstrapCoreMvc.Extensions
{
    public static class ComponentExtensions
    {
        public static BootstrapContent<TComponent> MergeAttribute<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string key,
            object? value,
            bool replaceExisting = false)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.MergeAttribute(key, value, replaceExisting);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> MergeAttribute<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            string key,
            object? value,
            bool replaceExisting = false)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.MergeAttribute(key, value, replaceExisting);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AddCss<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            params string[] cssClasses)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.AddCss(cssClasses);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> AddCss<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            params string[] cssClasses)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.AddCss(cssClasses);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AddStyle<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string name,
            string value)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.MergeStyle(name, value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> AddStyle<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            string name,
            string value)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.MergeStyle(name, value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AddStyles<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            object styles)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.MergeStyles(styles);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> AddStyles<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            object styles)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.MergeStyles(styles);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetTextBgState<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            TextBgState state = TextBgState.Primary)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.AddCss(state.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetBgState<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            BackgroundState state = BackgroundState.Primary)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.AddCss(state.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetId<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string? id = null)
            where TComponent : HtmlComponent
        {
            if (id == null)
                id = $"{typeof(TComponent).Name}_{DateTime.Now.Ticks}";
            bootstrapContent.Component.Id = id;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> SetId<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            string? id = null)
            where TComponent : HtmlComponent
        {
            if (id == null)
                id = $"{typeof(TComponent).Name}_{DateTime.Now.Ticks}";
            bootstrapContent.Component.Id = id;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetValue<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            object? value)
            where TComponent : HtmlComponent, ICanHaveValue
        {
            if (value == null)
                return bootstrapContent;

            bootstrapContent.Component.MergeAttribute("value", value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetName<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string? name)
            where TComponent : HtmlComponent, ICanHaveName
        {
            bootstrapContent.Component.MergeAttribute("name", name);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetDisabled<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            bool? value = true)
            where TComponent : HtmlComponent, ICanBeDisabled
        {
            if (value.HasValue && value == false)
                return bootstrapContent;
            bootstrapContent.Component.MergeAttribute("disabled");
            return bootstrapContent;
        }
    }
}
