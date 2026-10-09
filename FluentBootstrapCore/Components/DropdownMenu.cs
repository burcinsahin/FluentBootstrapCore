using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class DropdownMenu : BootstrapComponent,
        ICanCreate<DropdownItem>
    {
        public bool AlignEnd { get; set; }

        public DropdownMenu()
            : base("ul", Css.DropdownMenu)
        {
        }

        protected override void PreBuild()
        {
            if (AlignEnd)
                AddCss(Css.DropdownMenuEnd);

            base.PreBuild();
        }
    }
}