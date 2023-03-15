using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FBootstrapCoreMvc.Components
{
    public class GridColumn : SingleComponent
    {
        //public ColumnSize? Size { get; set; }
        //public bool Auto { get; set; }
        public Dictionary<Breakpoint, byte?> Width { get; set; }

        public GridColumn()
            : base("div", Css.Col)
        {
            Width = new Dictionary<Breakpoint, byte?>();
        }

        protected override void PreBuild()
        {
            //var colCss = Css.Col;
            //if (Size.HasValue)
            //{
            //    colCss = Size.GetCssDescription();
            //}
            if (Width.Any())
            {
                foreach (var w in Width)
                {
                    var colStr = "";
                    var br = "";
                    if (w.Key != Breakpoint.Default)
                        br = $"-{w.Key.GetCssDescription()}";
                    if (w.Value.HasValue)
                    {
                        if (w.Value == 0)
                            colStr = "-auto";
                        else if (w.Value > 0)
                            colStr = $"-{Math.Min(w.Value.Value, (byte)10)}";
                    }

                    AddCss($"col{br}{colStr}");
                }
            }
            //if (Auto)
            //{
            //    //RemoveCss(Css.Col);
            //    AddCss($"{colCss}-auto");
            //}
            //else if (Width > 0)
            //{
            //    Width = Math.Min(Width, 10);
            //    //RemoveCss(Css.Col);
            //    AddCss($"{colCss}-{Width}");
            //}
            base.PreBuild();
        }
    }
}
