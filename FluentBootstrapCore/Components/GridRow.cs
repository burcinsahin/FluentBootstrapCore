using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class GridRow : BootstrapComponent,
        ICanCreate<GridColumn>,
        IGutterable
    {
        public EnumList<RowColumn>? RowColumns { get; set; }

        public GridRow()
            : base("div", Css.Row)
        {
        }

        protected override void PreBuild()
        {
            if (RowColumns != null)
                AddCss(RowColumns.GetCssDescriptions());
            base.PreBuild();
        }
    }
}
