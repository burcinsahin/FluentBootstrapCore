using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Extensions
{
    public static class LayoutExtensions
    {
        #region Container
        public static BootstrapContent<Container> Fluid(this BootstrapContent<Container> bootstrapContent)
        {
            bootstrapContent.Component.RemoveCss(Css.Container);
            bootstrapContent.Component.AddCss(Css.ContainerFluid);
            return bootstrapContent;
        }

        public static BootstrapContent<Container> Responsive(this BootstrapContent<Container> bootstrapContent, ContainerSize size)
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

        public static BootstrapContent<HtmlElement> Break<TComponent>(this BootstrapBuilder<TComponent> builder)
            where TComponent : SingleComponent
        {
            var div = new HtmlElement("div", Css.W100);
            return new BootstrapContent<HtmlElement>(builder.HtmlHelper, div);
        }

        public static BootstrapContent<TComponent> Auto<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, IAuto
        {
            bootstrapContent.Component.Auto = true;
            return bootstrapContent;
        }

        public static BootstrapContent<GridRow> RowColumns(this BootstrapContent<GridRow> bootstrapContent, byte columnCount, Breakpoint breakpoint = Breakpoint.Default)
        {
            if (columnCount > 6)
                columnCount = 6;
            bootstrapContent.RowColumns((RowColumn)columnCount, breakpoint);
            return bootstrapContent;
        }

        private static BootstrapContent<GridRow> RowColumns(this BootstrapContent<GridRow> bootstrapContent, RowColumn columnCount, Breakpoint breakpoint = Breakpoint.Default)
        {
            if (bootstrapContent.Component.RowColumns == null)
                bootstrapContent.Component.RowColumns = new EnumList<RowColumn>();

            bootstrapContent.Component.RowColumns.TryAdd(breakpoint, columnCount);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AlignItems<TComponent>(this BootstrapContent<TComponent> bootstrapContent, AlignItems alignItem, Breakpoint br = Breakpoint.Default)
            where TComponent : SingleComponent, IAlignItem
        {
            if (bootstrapContent.Component.AlignItem == null)
                bootstrapContent.Component.AlignItem = new EnumList<AlignItems>();

            bootstrapContent.Component.AlignItem.TryAdd(br, alignItem);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Offset<TComponent>(this BootstrapContent<TComponent> bootstrapContent, byte offset, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : SingleComponent, IOffsetable
        {
            if (offset < 0) offset = 0;
            if (offset > 11) offset = 11;
            var offsetCss = $"offset{breakpoint.GetHyphenatedDescription()}-{offset}";
            bootstrapContent.Component.AddCss(offsetCss);
            return bootstrapContent;
        }
        #endregion

        public static BootstrapContent<TComponent> Gutter<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Gutter gutter, byte value, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : SingleComponent, IGutterable
        {
            value = value.Limit((byte)0, (byte)5);
            bootstrapContent.Component.AddCss($"{gutter.GetCssDescription()}{breakpoint.GetHyphenatedDescription()}-{value}");
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Columnize<TComponent>(this BootstrapContent<TComponent> bootstrapContent, byte? value = null, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : SingleComponent, IColumnizable
        {
            bootstrapContent.Component.RemoveCss(Css.Col);
            if (!value.HasValue)
            {
                bootstrapContent.Component.AddCss($"col{breakpoint.GetHyphenatedDescription()}");
                return bootstrapContent;
            }

            value = value.Value.Limit((byte)0, (byte)10);
            if (value == 0)
            {
                bootstrapContent.Component.AddCss($"col{breakpoint.GetHyphenatedDescription()}-auto");
                return bootstrapContent;
            }
            bootstrapContent.Component.AddCss($"col{breakpoint.GetHyphenatedDescription()}-{value}");
            return bootstrapContent;
        }
    }
}
