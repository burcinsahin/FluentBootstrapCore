using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class InputGroup : BootstrapComponent,
        ICanCreate<Input>
    {
        public InputGroup() : base("div", Css.InputGroup)
        {
        }

        protected override void PreBuild()
        {
            MergeAttribute("role", "group");

            base.PreBuild();
        }
    }
}