using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Extensions
{
    public static class LayoutExtensions
    {
        #region Container
        public static BootstrapContent<Container> SetFluid(this BootstrapContent<Container> bootstrapContent)
        {
            bootstrapContent.Component.RemoveCss(Css.Container);
            bootstrapContent.Component.AddCss(Css.ContainerFluid);
            return bootstrapContent;
        }

        public static BootstrapContent<Container> SetResponsive(this BootstrapContent<Container> bootstrapContent, ContainerSize size)
        {
            bootstrapContent.Component.RemoveCss(Css.Container);
            bootstrapContent.Component.AddCss(size.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<Container> TextCenter(this BootstrapContent<Container> bootstrapContent)
        {
            bootstrapContent.Component.TextCentered = true;
            return bootstrapContent;
        }
        #endregion

        #region Grid
        public static BootstrapContent<GridRow> Row<TComponent>(this BootstrapBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<GridRow>
        {
            var gridRow = new GridRow();
            return new BootstrapContent<GridRow>(builder.HtmlHelper, gridRow);
        }

        public static BootstrapContent<GridColumn> Column<TComponent>(this BootstrapBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<GridColumn>
        {
            var gridColumn = new GridColumn();
            return new BootstrapContent<GridColumn>(builder.HtmlHelper, gridColumn);
        }
        #endregion

        #region Margin
        public static BootstrapContent<TComponent> Margin<TComponent>(this BootstrapContent<TComponent> bootstrapContent, int top = 0, int right = 0, int bottom = 0, int left = 0)
            where TComponent : SingleComponent
        {
            var component = bootstrapContent.Component;
            if (top > 0)
            {
                if (top > 5) top = 5;
                component.AddCss($"mt-{top}");
            }
            if (right > 0)
            {
                if (right > 5) right = 5;
                component.AddCss($"me-{right}");
            }
            if (bottom > 0)
            {
                if (bottom > 5) bottom = 5;
                component.AddCss($"mb-{bottom}");
            }
            if (left > 0)
            {
                if (left > 5) left = 5;
                component.AddCss($"ms-{left}");
            }
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Margin<TComponent>(this BootstrapContent<TComponent> bootstrapContent, int all = 0)
            where TComponent : SingleComponent
        {
            var component = bootstrapContent.Component;
            if (all > 0)
            {
                if (all > 5) all = 5;
                component.AddCss($"m-{all}");
            }
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AutoMargin<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(Css.MAuto);
            return bootstrapContent;
        }
        #endregion
    }
}
