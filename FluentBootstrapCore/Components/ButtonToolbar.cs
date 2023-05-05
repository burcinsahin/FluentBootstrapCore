using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class ButtonToolbar : BootstrapComponent,
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
            if (JustifyContent != null)
                AddCss(JustifyContent.GetCssDescriptions());
            base.PreBuild();
        }
    }
}