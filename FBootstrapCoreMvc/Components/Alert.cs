using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Alert : Component<Alert>
    {
        public Alert(IHtmlHelper helper)
            : base(helper, "div", Css.Alert)
        {
        }
    }
}