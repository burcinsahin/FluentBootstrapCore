using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class ButtonGroup : HtmlComponent, ICanCreate<IButton>
    {
        public ButtonGroup() : base("div", Css.BtnGroup)
        {
            MergeAttribute("role", "group");
        }

        protected override void PreBuild()
        {

            base.PreBuild();
        }
    }
}