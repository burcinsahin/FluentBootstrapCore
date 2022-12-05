using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class GridRow : HtmlComponent,
        ICanCreate<GridColumn>
    {
        public GridRow()
            : base("div", Css.Row)
        {
        }
    }
}
