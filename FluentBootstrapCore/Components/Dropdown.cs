using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Wrapper of a dropdown toggle and its menu (<c>div.dropdown</c>).
    /// </summary>
    public class Dropdown : BootstrapComponent,
        IDropdownContainer,
        ICanCreate<Button>,
        ICanCreate<LinkButton>,
        ICanCreate<DropdownMenu>
    {
        public DropdownDirection Direction { get; set; }
        public bool Centered { get; set; }

        public Dropdown()
            : base("div", Css.Dropdown)
        {
        }

        protected override void PreBuild()
        {
            ApplyDirection(this, this);
            base.PreBuild();
        }

        /// <summary>
        /// Adds the direction/centered classes of a dropdown container to the component.
        /// </summary>
        internal static void ApplyDirection(SingleComponent component, IDropdownContainer container)
        {
            if (container.Direction == DropdownDirection.Down && !container.Centered)
                return;

            component.RemoveCss(Css.Dropdown);
            switch (container.Direction)
            {
                case DropdownDirection.Down:
                    component.AddCss(Css.DropdownCenter);
                    break;
                case DropdownDirection.Up:
                    if (container.Centered)
                        component.AddCss(Css.DropupCenter);
                    component.AddCss(Css.Dropup);
                    break;
                case DropdownDirection.End:
                    component.AddCss(Css.Dropend);
                    break;
                case DropdownDirection.Start:
                    component.AddCss(Css.Dropstart);
                    break;
            }
        }
    }
}
