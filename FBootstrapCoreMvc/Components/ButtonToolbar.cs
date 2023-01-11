using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class ButtonToolbar : SingleComponent,
        ICanCreate<ButtonGroup>
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