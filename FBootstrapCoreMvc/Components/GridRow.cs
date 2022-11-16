using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class GridRow : Component<GridRow>,
        ICanCreate<GridColumn>
    {
        public GridRow(IHtmlHelper helper)
            : base(helper, "div", Css.Row)
        {
        }
    }
}
