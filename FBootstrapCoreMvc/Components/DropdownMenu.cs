using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class DropdownMenu : BootstrapComponent,
        ICanCreate<DropdownItem>
    {
        public DropdownMenu()
            : base("ul", Css.DropdownMenu)
        {
        }
    }
}