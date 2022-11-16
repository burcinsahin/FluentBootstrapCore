using FBootstrapCoreMvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class CardBody : Component<CardBody>
    {
        public CardBody(IHtmlHelper helper)
            : base(helper, "div", Css.CardBody)
        {
        }
    }
}