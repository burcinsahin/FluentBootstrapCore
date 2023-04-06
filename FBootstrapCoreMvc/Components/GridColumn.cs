using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class GridColumn : BootstrapComponent,
        IAlignSelf,
        IOffsetable,
        IColumnizable
    {
        public EnumList<AlignSelf>? AlignSelf { get; set; }

        public GridColumn()
            : base("div", Css.Col)
        {
        }

        protected override void PreBuild()
        {
            if (AlignSelf != null)
                AddCss(AlignSelf.GetCssDescriptions());

            base.PreBuild();
        }
    }
}
