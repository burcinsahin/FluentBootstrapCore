using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class GridColumn : BootstrapComponent,
        IAlignSelf,
        IOrderable,
        IOffsetable,
        IColumnizable
    {
        public EnumList<AlignSelf>? AlignSelf { get; set; }
        public Order? Order { get; set; }

        public GridColumn()
            : base("div", Css.Col)
        {
        }

        protected override void PreBuild()
        {
            if (AlignSelf != null)
                AddCss(AlignSelf.GetCssDescriptions());

            if (Order.HasValue)
                AddCss(Order.GetCssDescription());

            base.PreBuild();
        }
    }
}
