using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Extensions
{
    public static class TableExtensions
    {
        public static BootstrapContent<Table> Style(this BootstrapContent<Table> bootstrapContent, TableStyle tableStyle)
        {
            bootstrapContent.Component.SetStyle(tableStyle);
            return bootstrapContent;
        }

        public static BootstrapContent<Table> Responsive(this BootstrapContent<Table> bootstrapContent)
        {
            bootstrapContent.Component.SetResponsive();
            return bootstrapContent;
        }

        public static BootstrapContent<Table> Caption(this BootstrapContent<Table> bootstrapContent, string caption)
        {
            bootstrapContent.Component.SetCaption(caption);
            return bootstrapContent;
        }

        // Sections

        //public static ComponentBuilder<TConfig, TableHeadSection> TableHeadSection<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
        //    where TConfig : BootstrapConfig
        //    where TComponent : Component, ICanCreate<TableHeadSection>
        //{
        //    return new ComponentBuilder<TConfig, TableHeadSection>(helper.Config, new TableHeadSection(helper));
        //}

        //public static ComponentBuilder<TConfig, TableBodySection> TableBodySection<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
        //    where TConfig : BootstrapConfig
        //    where TComponent : Component, ICanCreate<TableBodySection>
        //{
        //    return new ComponentBuilder<TConfig, TableBodySection>(helper.Config, new TableBodySection(helper));
        //}

        //public static ComponentBuilder<TConfig, TableFootSection> TableFootSection<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
        //    where TConfig : BootstrapConfig
        //    where TComponent : Component, ICanCreate<TableFootSection>
        //{
        //    return new ComponentBuilder<TConfig, TableFootSection>(helper.Config, new TableFootSection(helper));
        //}

        // TableRow

        //public static ComponentBuilder<TConfig, TableRow> TableRow<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
        //    where TConfig : BootstrapConfig
        //    where TComponent : Component, ICanCreate<TableRow>
        //{
        //    return new ComponentBuilder<TConfig, TableRow>(helper.Config, new TableRow(helper));
        //}

        // Cells
        public static BootstrapContent<TableHeader> TableHeader<TComponent>(this ComponentBuilder<TComponent> builder, params string[] headers)
            where TComponent : SingleComponent, ICanCreate<TableHeader>
        {
            return new BootstrapContent<TableHeader>(builder.HtmlHelper, new TableHeader(headers));
        }

        public static BootstrapContent<TableRow> TableRow<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<TableRow>
        {
            return new BootstrapContent<TableRow>(builder.HtmlHelper, new TableRow());
        }

        public static BootstrapContent<TableData> TableData<TComponent>(this ComponentBuilder<TComponent> builder, object? content = null)
            where TComponent : SingleComponent, ICanCreate<TableData>
        {
            return new BootstrapContent<TableData>(builder.HtmlHelper, new TableData(content));
        }
    }
}
