using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    internal class CardHeader : Component<CardHeader>
    {
        public CardHeader(IHtmlHelper helper)
            : base(helper, "div", Css.CardHeader)
        {
        }
    }
}