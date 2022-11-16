using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FBootstrapCoreMvc.Extensions
{
    public static class LayoutExtensions
    {
        public static GridRow Row<TComponent>(this HtmlBuilder<TComponent> builder)
            where TComponent : Component<TComponent>, ICanCreate<GridRow>
        {
            return new GridRow(builder.HtmlHelper);
        }

        public static GridColumn Column<TComponent>(this HtmlBuilder<TComponent> builder)
            where TComponent : Component<TComponent>, ICanCreate<GridColumn>
        {
            return new GridColumn(builder.HtmlHelper);
        }
    }
}
