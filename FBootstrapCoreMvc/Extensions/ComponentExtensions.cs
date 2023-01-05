using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using System;

namespace FBootstrapCoreMvc.Extensions
{
    public static class ComponentExtensions
    {
        #region Common
        public static BootstrapContent<TComponent> SetContent<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            object content)
            where TComponent : HtmlComponent
        {
            bootstrapContent.Component.Content = content;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> RenderIf<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            bool condition)
            where TComponent : HtmlComponent
        {
            if (condition == false)
                bootstrapContent.Component.RenderMode = RenderMode.None;
            return bootstrapContent;
        }

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
        #endregion

        #region Interface Filtered
        public static BootstrapContent<TComponent> SetDisabled<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            bool value = true)
            where TComponent : HtmlComponent, ICanBeDisabled
        {
            bootstrapContent.Component.Disabled = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetValue<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            object? value)
            where TComponent : HtmlComponent, ICanHaveValue
        {
            if (value == null)
                return bootstrapContent;

            bootstrapContent.Component.MergeAttribute("value", value, true);
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

        public static BootstrapContent<TComponent> AddBadge<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string? badge)
            where TComponent : HtmlComponent, ICanHaveBadge
        {
            bootstrapContent.Component.Badge = badge;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> PositionBadge<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : HtmlComponent, ICanPositionBadge
        {
            bootstrapContent.Component.PositionBadge = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Active<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : HtmlComponent, ICanBeActive
        {
            bootstrapContent.Component.Active = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Href<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent, string href = "#")
            where TComponent : HtmlComponent, ILink
        {
            bootstrapContent.Component.Href = href;
            return bootstrapContent;
        }
        #endregion
    }
}