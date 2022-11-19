using FBootstrapCoreMvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class CardBody : HtmlComponent
    {
        public CardBody()
            : base("div", Css.CardBody)
        {
        }
    }
}