using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
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