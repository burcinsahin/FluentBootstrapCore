using FBootstrapCoreMvc.Enums;
using System;

namespace FBootstrapCoreMvc.Extensions
{
    public static class ComponentExtensions
    {
        #region Common
        public static BootstrapContent<TComponent> Content<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            object content, bool isHtml = false)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.Content = content;
            bootstrapContent.Component.IsContentHtml = isHtml;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> RenderIf<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            bool condition)
            where TComponent : SingleComponent
        {
            if (condition == false)
                bootstrapContent.Component.RenderMode = RenderMode.None;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> MergeAttribute<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string key,
            object? value = null,
            bool replaceExisting = false)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeAttribute(key, value, replaceExisting);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> MergeAttribute<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            string key,
            object? value,
            bool replaceExisting = false)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeAttribute(key, value, replaceExisting);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AddCss<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            params string[] cssClasses)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(cssClasses);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> AddCss<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            params string[] cssClasses)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(cssClasses);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AddStyle<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string name,
            string value)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle(name, value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> AddStyle<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            string name,
            string value)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle(name, value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AddStyles<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            object styles)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle(styles);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> AddStyles<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            object styles)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle(styles);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> TextBackground<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            TextBgState state = TextBgState.Primary)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(state.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Background<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            BackgroundState state = BackgroundState.Primary)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(state.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetId<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string? id = null)
            where TComponent : SingleComponent
        {
            if (id == null)
                id = $"{typeof(TComponent).Name}_{DateTime.Now.Ticks}";
            bootstrapContent.Component.Id = id;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> SetId<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            string? id = null)
            where TComponent : SingleComponent
        {
            if (id == null)
                id = $"{typeof(TComponent).Name}_{DateTime.Now.Ticks}";
            bootstrapContent.Component.Id = id;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Clearfix<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(Css.Clearfix);
            return bootstrapContent;
        }
        #endregion
    }
}