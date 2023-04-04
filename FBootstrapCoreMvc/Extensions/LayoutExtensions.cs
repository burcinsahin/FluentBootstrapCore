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

        public static BootstrapContent<TComponent> AlignItems<TComponent>(this BootstrapContent<TComponent> bootstrapContent, AlignItem alignItem)
            where TComponent : SingleComponent, IAlignItem
        {
            bootstrapContent.Component.AlignItem = alignItem;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AlignSelf<TComponent>(this BootstrapContent<TComponent> bootstrapContent, AlignSelf alignSelf)
            where TComponent : SingleComponent, IAlignSelf
        {
            bootstrapContent.Component.AlignSelf = alignSelf;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Order<TComponent>(this BootstrapContent<TComponent> bootstrapContent, byte order)
            where TComponent : SingleComponent, IOrderable
        {
            if (order == byte.MinValue)
                bootstrapContent.Component.AddCss(Css.OrderFirst);
            else if (order == byte.MaxValue)
                bootstrapContent.Component.AddCss(Css.OrderLast);
            else
            {
                if (order < 0) order = 0;
                if (order > 5) order = 5;
                bootstrapContent.Component.AddCss($"order-{order}");
            }
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

        /// <summary>
        /// Sets column width
        /// </summary>
        /// <param name="bootstrapContent"></param>
        /// <param name="width">0 for auto.</param>
        /// <param name="breakpoint">Optional. Default xs.</param>
        /// <returns></returns>
        //public static BootstrapContent<GridColumn> Columnize(this BootstrapContent<GridColumn> bootstrapContent, byte? width = null, Breakpoint breakpoint = Breakpoint.Default)
        //{
        //    bootstrapContent.Component.Width.TryAdd(breakpoint, width);
        //    return bootstrapContent;
        //}
        #endregion

        #region Margin, Padding, Float
        public static BootstrapContent<TComponent> Margin<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Margin margin, byte? value = null, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : SingleComponent
        {
            if (!value.HasValue)
            {
                bootstrapContent.Component.AddCss($"{margin.GetCssDescription()}{breakpoint.GetHyphenatedDescription()}-auto");
                return bootstrapContent;
            }

            value = value.Trim((byte)0, (byte)5);
            bootstrapContent.Component.AddCss($"{margin.GetCssDescription()}{breakpoint.GetHyphenatedDescription()}-{value}");
            return bootstrapContent;
        }

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

        public static BootstrapContent<TComponent> Padding<TComponent>(this BootstrapContent<TComponent> bootstrapContent, byte value, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : SingleComponent
        {
            bootstrapContent.Padding(Enums.Padding.All, value, breakpoint);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Padding<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Padding padding, byte? value = null, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : SingleComponent
        {
            if (!value.HasValue)
            {
                bootstrapContent.Component.AddCss($"{padding.GetCssDescription()}{breakpoint.GetHyphenatedDescription()}-auto");
                return bootstrapContent;
            }

            value = value.Value.Trim((byte)0, (byte)5);
            bootstrapContent.Component.AddCss($"{padding.GetCssDescription()}{breakpoint.GetHyphenatedDescription()}-{value}");
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Gutter<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Gutter gutter, byte value, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : SingleComponent, IGutterable
        {
            value = value.Trim((byte)0, (byte)5);
            bootstrapContent.Component.AddCss($"{gutter.GetCssDescription()}{breakpoint.GetHyphenatedDescription()}-{value}");
            return bootstrapContent;
        }
        #endregion

        public static BootstrapContent<TComponent> Columnize<TComponent>(this BootstrapContent<TComponent> bootstrapContent, byte? value = null, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : SingleComponent, IColumnizable
        {
            bootstrapContent.Component.RemoveCss(Css.Col);
            if (!value.HasValue)
            {
                bootstrapContent.Component.AddCss($"col{breakpoint.GetHyphenatedDescription()}");
                return bootstrapContent;
            }

            value = value.Value.Trim((byte)0, (byte)10);
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
