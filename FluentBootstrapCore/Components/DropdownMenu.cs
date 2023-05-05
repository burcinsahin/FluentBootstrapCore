using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
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