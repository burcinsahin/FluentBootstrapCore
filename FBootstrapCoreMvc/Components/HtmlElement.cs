using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class HtmlElement : Component<HtmlElement>
    {
        public HtmlElement(IHtmlHelper helper, string tagName, params string[] cssClasses) 
            : base(helper, tagName, cssClasses)
        {
        }
    }
}
