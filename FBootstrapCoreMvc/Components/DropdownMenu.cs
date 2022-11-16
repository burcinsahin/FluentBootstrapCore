using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class DropdownMenu : Component<DropdownMenu>,
        ICanCreate<DropdownItem>
    {
        public DropdownMenu(IHtmlHelper helper)
            : base(helper, "ul", Css.DropdownMenu)
        {
        }
    }
}