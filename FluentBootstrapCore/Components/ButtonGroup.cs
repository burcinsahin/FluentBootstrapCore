using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class ButtonGroup : BootstrapComponent,
        ICanCreate<IButton>,
        ICanCreate<ButtonGroup>,
        ICanCreate<DropdownMenu>,
        ISizable<ButtonGroupSize>
    {
        public ButtonGroupSize? Size { get; set; }
        public bool Vertical { get; set; }
        public ButtonGroup() : base("div", Css.BtnGroup)
        {
        }

        protected override void PreBuild()
        {
            MergeAttribute("role", "group");

            if (Size.HasValue)
                AddCss(Size.GetCssDescription());

            if (Vertical)
            {
                RemoveCss(Css.BtnGroup);
                AddCss(Css.BtnGroupVertical);
            }

            base.PreBuild();
        }
    }
}