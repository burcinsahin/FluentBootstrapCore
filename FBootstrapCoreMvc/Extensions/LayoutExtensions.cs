using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Extensions
{
    public static class LayoutExtensions
    {
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
    }
}
