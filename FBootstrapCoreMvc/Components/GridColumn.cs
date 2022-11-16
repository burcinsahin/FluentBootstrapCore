using FBootstrapCoreMvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class GridColumn : Component<GridColumn>
    {
        public GridColumn(IHtmlHelper helper)
            : base(helper, "div", Css.Col)
        {
        }
    }
}
