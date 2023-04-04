using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class GridRow : SingleComponent,
        ICanCreate<GridColumn>,
        IJustifyContent,
        IAlignItem,
        IGutterable
    {
        public EnumList<JustifyContent>? JustifyContent { get; set; }
        public EnumList<RowColumn>? RowColumns { get; set; }
        public AlignItem? AlignItem { get; set; }
        public GridRow()
            : base("div", Css.Row)
        {
        }

        protected override void PreBuild()
        {
            if (JustifyContent != null)
                AddCss(JustifyContent.GetCssDescriptions());

            if (AlignItem.HasValue)
                AddCss(AlignItem.GetCssDescription());

            if (RowColumns != null)
            {
                AddCss(RowColumns.GetCssDescriptions());
                //var br = "";
                //var colCount = "auto";
                //foreach (var rowColumn in RowColumns)
                //{
                //    if (rowColumn.Key != Breakpoint.Default)
                //        br = $"-{rowColumn.Key.GetCssDescription()}";
                //    if (rowColumn.Value > 0)
                //        colCount = Math.Min(rowColumn.Value, (byte)6).ToString();
                //    AddCss($"row-cols{br}-{colCount}");
                //}
            }
            base.PreBuild();
        }
    }
}
