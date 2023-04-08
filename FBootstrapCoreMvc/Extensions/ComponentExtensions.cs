using FBootstrapCoreMvc.Enums;
using System;
using System.Globalization;

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

        public static BootstrapContent<TComponent> Css<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            params string[] cssClasses)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(cssClasses);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> Css<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            params string[] cssClasses)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(cssClasses);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Style<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string name,
            string value)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle(name, value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> Style<TComponent, TModel>(
            this BootstrapContent<TComponent, TModel> bootstrapContent,
            string name,
            string value)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle(name, value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Style<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            object styles)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle(styles);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> Style<TComponent, TModel>(
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

        //public static BootstrapContent<TComponent> Background<TComponent>(
        //    this BootstrapContent<TComponent> bootstrapContent,
        //    BackgroundColor state = BackgroundColor.Primary)
        //    where TComponent : SingleComponent
        //{
        //    bootstrapContent.Component.AddCss(state.GetCssDescription());
        //    return bootstrapContent;
        //}

        public static BootstrapContent<TComponent> Id<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string? id = null)
            where TComponent : SingleComponent
        {
            if (id == null)
                id = $"{typeof(TComponent).Name}_{DateTime.Now.Ticks}";
            bootstrapContent.Component.Id = id;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent, TModel> Id<TComponent, TModel>(
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
            bootstrapContent.Component.AddCss(FBootstrapCoreMvc.Css.Clearfix);
            return bootstrapContent;
        }

        #region Styles
        public static BootstrapContent<TComponent> Height<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            double value, LengthUnit unit = LengthUnit.Pixel) where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle("height", $"{value.ToString("0.###", CultureInfo.InvariantCulture)}{unit.GetDescription()}");
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Width<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            double value, LengthUnit unit = LengthUnit.Pixel) where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle("width", $"{value.ToString("0.###", CultureInfo.InvariantCulture)}{unit.GetDescription()}");
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> MaxHeight<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            double value,
            LengthUnit unit = LengthUnit.Pixel) where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle("max-height", $"{value.ToString("0.###", CultureInfo.InvariantCulture)}{unit.GetDescription()}");
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> MaxWidth<TComponent>(this BootstrapContent<TComponent> bootstrapContent,
            double value,
            LengthUnit unit = LengthUnit.Pixel) where TComponent : SingleComponent
        {
            bootstrapContent.Component.MergeStyle("max-width", $"{value.ToString("0.###", CultureInfo.InvariantCulture)}{unit.GetDescription()}");
            return bootstrapContent;
        }
        #endregion
        #endregion
    }
}