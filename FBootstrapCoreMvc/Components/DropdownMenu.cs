using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class DropdownMenu : HtmlComponent,
        ICanCreate<DropdownItem>
    {
        public DropdownMenu()
            : base("ul", Css.DropdownMenu)
        {
        }
    }
}