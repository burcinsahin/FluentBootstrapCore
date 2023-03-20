using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FBootstrapCoreMvc.Components
{
    public class GridColumn : SingleComponent,
        IAlignSelf,
        IOrderable,
        IOffsetable,
        IColumnizable
    {
        //public Dictionary<Breakpoint, byte?> Width { get; set; }
        public AlignSelf? AlignSelf { get; set; }
        public Order? Order { get; set; }

        public GridColumn()
            : base("div", Css.Col)
        {
            //Width = new Dictionary<Breakpoint, byte?>();
        }

        protected override void PreBuild()
        {
            if (AlignSelf.HasValue)
                AddCss(AlignSelf.GetCssDescription());
            
            if(Order.HasValue)
                AddCss(Order.GetCssDescription());

            //if (Width.Any())
            //{
            //    RemoveCss(Css.Col);
            //    foreach (var w in Width)
            //    {
            //        var colStr = "";
            //        var br = w.Key.GetHyphenatedDescription();
            //        if (w.Value.HasValue)
            //        {
            //            if (w.Value == 0)
            //                colStr = "-auto";
            //            else if (w.Value > 0)
            //                colStr = $"-{Math.Min(w.Value.Value, (byte)10)}";
            //        }

            //        AddCss($"col{br}{colStr}");
            //    }
            //}
            base.PreBuild();
        }
    }
}
