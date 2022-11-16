using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class CardFooter : Component<CardFooter>
    {
        public CardFooter(IHtmlHelper helper)
            : base(helper, "div", Css.CardFooter)
        {
        }
    }
}