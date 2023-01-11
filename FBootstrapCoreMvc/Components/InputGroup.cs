using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class InputGroup : SingleComponent
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