using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class ButtonToolbar : BootstrapComponent,
        ICanCreate<ButtonGroup>,
        ICanCreate<InputGroup>
    {
        public ButtonToolbar() : base("div", Css.BtnToolbar)
        {
        }

        protected override void PreBuild()
        {
            MergeAttribute("role", "toolbar");
            base.PreBuild();
        }
    }
}
