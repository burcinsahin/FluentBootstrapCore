using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using System;
using System.Collections;

namespace FluentBootstrapCore.Extensions
{
    public static class TableExtensions
    {
        public static BootstrapContent<Table> Style(
            this BootstrapContent<Table> bootstrapContent,
            TableStyle tableStyle)
        {
            bootstrapContent.Component.Style = tableStyle;
            return bootstrapContent;
        }

        public static BootstrapContent<Table> Responsive(
            this BootstrapContent<Table> bootstrapContent,
            Breakpoint value = Breakpoint.Default)
        {
            bootstrapContent.Component.Responsive = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Caption<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string caption, bool captionTop = false) where TComponent : Table
        {
            bootstrapContent.Component.Caption = caption;
            bootstrapContent.Component.CaptionTop = captionTop;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> ColSpan<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            int value)
            where TComponent : TableData
        {
            bootstrapContent.Component.ColSpan = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> State<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            TableState value)
            where TComponent : BootstrapComponent, ITableState
        {
            bootstrapContent.Component.State = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Hover<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            bool value = true)
            where TComponent : Table
        {
            bootstrapContent.Component.Hover = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Small<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            bool value = true) where TComponent : Table
        {
            bootstrapContent.Component.Small = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Data<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            params object[] value) where TComponent : BootstrapComponent, ITableData
        {
            bootstrapContent.Component.Data = value;
            return bootstrapContent;
        }

        #region Builder
        public static BootstrapContent<TableHeader> Header<TComponent>(
            this ComponentBuilder<TComponent> builder,
            params string[] headers)
            where TComponent : BootstrapComponent, ICanCreate<TableHeader>
        {
            var thead = new TableHeader() { Data = headers };
            return new BootstrapContent<TableHeader>(builder.HtmlHelper, thead);
        }

        public static BootstrapContent<TableBody> Body<TComponent>(
            this ComponentBuilder<TComponent> builder, bool divider = false)
            where TComponent : BootstrapComponent, ICanCreate<TableHeader>
        {
            var tbody = new TableBody() { Divider = divider };
            return new BootstrapContent<TableBody>(builder.HtmlHelper, tbody);
        }

        public static BootstrapContent<TableFooter> Footer<TComponent>(
            this ComponentBuilder<TComponent> builder, params object[] values)
            where TComponent : BootstrapComponent, ICanCreate<TableHeader>
        {
            var tfoot = new TableFooter() { Data = values };
            return new BootstrapContent<TableFooter>(builder.HtmlHelper, tfoot);
        }

        public static BootstrapContent<TableRow> Row<TComponent>(
            this ComponentBuilder<TComponent> builder,
            params object[] values)
            where TComponent : BootstrapComponent, ICanCreate<TableRow>
        {
            var tr = new TableRow() { Data = values };
            return new BootstrapContent<TableRow>(builder.HtmlHelper, tr);
        }

        public static BootstrapContent<TableData> Data<TComponent>(
            this ComponentBuilder<TComponent> builder,
            object? content = null)
            where TComponent : BootstrapComponent, ICanCreate<TableData>
        {
            var td = new TableData() { Content = content };
            return new BootstrapContent<TableData>(builder.HtmlHelper, td);
        }

        public static BootstrapContent<TableData> HeaderData<TComponent>(
            this ComponentBuilder<TComponent> builder,
            object? content = null)
            where TComponent : BootstrapComponent, ICanCreate<TableData>
        {
            var th = new TableData(true) { Content = content };
            return new BootstrapContent<TableData>(builder.HtmlHelper, th);
        }
        #endregion
    }
}
