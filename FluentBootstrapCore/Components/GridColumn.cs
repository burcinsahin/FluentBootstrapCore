using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class GridColumn : BootstrapComponent,
        IOffsetable
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
