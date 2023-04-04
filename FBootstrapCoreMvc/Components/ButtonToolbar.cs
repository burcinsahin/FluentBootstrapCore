using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class ButtonToolbar : SingleComponent,
        ICanCreate<ButtonGroup>,
        ICanCreate<InputGroup>,
        IJustifyContent
    {
        public ButtonToolbar() : base("div", Css.BtnToolbar)
        {
        }

        public EnumList<JustifyContent>? JustifyContent { get; set; }

        protected override void PreBuild()
        {
            MergeAttribute("role", "toolbar");
            if (JustifyContent!=null)
                AddCss(JustifyContent.GetCssDescriptions());
            base.PreBuild();
        }
    }
}