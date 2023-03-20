using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FBootstrapCoreMvc.Components
{
    public class GridRow : SingleComponent,
        ICanCreate<GridColumn>,
        IJustifyContent,
        IAlignItem,
        IGutterable
    {
        public JustifyContent? JustifyContent { get; set; }
        public Dictionary<Breakpoint, byte> RowColumns { get; set; }
        public AlignItem? AlignItem { get; set; }
        public GridRow()
            : base("div", Css.Row)
        {
            RowColumns = new Dictionary<Breakpoint, byte>();
        }

        protected override void PreBuild()
        {
            if (JustifyContent.HasValue)
                AddCss(JustifyContent.GetCssDescription());
            
            if (AlignItem.HasValue)
                AddCss(AlignItem.GetCssDescription());

            if (RowColumns.Any())
            {
                var br = "";
                var colCount = "auto";
                foreach (var rowColumn in RowColumns)
                {
                    if (rowColumn.Key != Breakpoint.Default)
                        br = $"-{rowColumn.Key.GetCssDescription()}";
                    if (rowColumn.Value > 0)
                        colCount = Math.Min(rowColumn.Value, (byte)6).ToString();
                    AddCss($"row-cols{br}-{colCount}");
                }
            }
            base.PreBuild();
        }
    }
}
