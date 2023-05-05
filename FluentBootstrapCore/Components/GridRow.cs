using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class GridRow : BootstrapComponent,
        ICanCreate<GridColumn>,
        IJustifyContent,
        IAlignItem,
        IGutterable
    {
        public EnumList<JustifyContent>? JustifyContent { get; set; }
        public EnumList<RowColumn>? RowColumns { get; set; }
        public EnumList<AlignItems>? AlignItem { get; set; }

        public GridRow()
            : base("div", Css.Row)
        {
        }

        protected override void PreBuild()
        {
            if (JustifyContent != null)
                AddCss(JustifyContent.GetCssDescriptions());

            if (AlignItem != null)
                AddCss(AlignItem.GetCssDescriptions());

            if (RowColumns != null)
                AddCss(RowColumns.GetCssDescriptions());
            base.PreBuild();
        }
    }
}
