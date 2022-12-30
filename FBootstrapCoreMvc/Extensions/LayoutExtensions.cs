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
    where TComponent : HtmlComponent, ICanCreate<GridRow>
        {
            var gridRow = new GridRow();
            return new BootstrapContent<GridRow>(builder.HtmlHelper, gridRow);
        }

        public static BootstrapContent<GridColumn> Column<TComponent>(this BootstrapBuilder<TComponent> builder)
            where TComponent : HtmlComponent, ICanCreate<GridColumn>
        {
            var gridColumn = new GridColumn();
            return new BootstrapContent<GridColumn>(builder.HtmlHelper, gridColumn);
        }
        #endregion
    }
}
