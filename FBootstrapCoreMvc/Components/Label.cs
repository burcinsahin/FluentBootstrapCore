using FBootstrapCoreMvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Label : Component<Label>
    {
        public Label(IHtmlHelper helper, string? text = null)
            : base(helper, "label")
        {
            if (text != null)
                InnerHtml.Append(text);
        }
    }
}