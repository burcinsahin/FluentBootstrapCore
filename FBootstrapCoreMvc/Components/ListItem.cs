using FBootstrapCoreMvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class ListItem : Component<ListItem>
    {
        public ListItem(IHtmlHelper helper)
            : base(helper, "li", Css.ListGroupItem)
        {
        }
    }
}