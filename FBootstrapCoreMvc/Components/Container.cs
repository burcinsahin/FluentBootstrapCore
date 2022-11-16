using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Container : Component<Container>,
        ICanCreate<GridRow>
    {
        public Container(IHtmlHelper helper)
            : base(helper, "div", Css.Container)
        {
        }

        public Container TextCenter()
        {
            AddCssClass(Css.TextCenter);
            return this;
        }
    }
}
