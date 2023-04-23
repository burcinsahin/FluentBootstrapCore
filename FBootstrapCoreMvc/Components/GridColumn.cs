using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class GridColumn : BootstrapComponent,
        IOffsetable,
        IColumnizable
    {
        public GridColumn()
            : base("div", Css.Col)
        {
        }

        protected override void PreBuild()
        {
            base.PreBuild();
        }
    }
}
