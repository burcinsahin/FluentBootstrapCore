using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class GridRow : SingleComponent,
        ICanCreate<GridColumn>
    {
        public GridRow()
            : base("div", Css.Row)
        {
        }
    }
}
