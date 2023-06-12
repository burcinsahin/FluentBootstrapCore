using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class InputButton : ButtonComponent,
        ICanHaveValue
    {
        public InputButton() : base("input")
        {
        }

        public object? Value { get; set; }

        protected override void PreBuild()
        {
            MergeAttribute("type", ButtonType.GetDescription());

            if (Value != null)
                MergeAttribute("value", Value);

            base.PreBuild();
        }
    }
}