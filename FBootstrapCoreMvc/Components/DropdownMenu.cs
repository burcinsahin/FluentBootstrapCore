using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class DropdownMenu : SingleComponent,
        ICanCreate<DropdownItem>
    {
        public DropdownMenu()
            : base("ul", Css.DropdownMenu)
        {
        }
    }
}