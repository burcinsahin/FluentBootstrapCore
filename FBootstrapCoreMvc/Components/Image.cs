using FBootstrapCoreMvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Image : Component<Image>
    {
        public Image(IHtmlHelper helper)
            : base(helper, "img")
        {
        }
    }
}
