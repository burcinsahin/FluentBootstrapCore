using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class ButtonGroup : BootstrapComponent,
        ICanCreate<IButton>,
        ICanCreate<ButtonGroup>,
        ICanCreate<DropdownMenu>
    {
        public ButtonGroupSize Size { get; set; }
        public bool Vertical { get; set; }
        public ButtonGroup() : base("div", Css.BtnGroup)
        {
        }

        protected override void PreBuild()
        {
            MergeAttribute("role", "group");
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