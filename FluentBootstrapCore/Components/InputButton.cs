using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class InputButton : ButtonComponent,
        ICanHaveValue,
        ICanBeDisabled
    {
        public InputButton() : base("input")
        {
        }

        public object? Value { get; set; }
        //public bool Disabled { get; set; }

        protected override void PreBuild()
        {
            MergeAttribute("type", ButtonType.GetDescription());

            if (Value != null)
                MergeAttribute("value", Value);
            if (Disabled)
                MergeAttribute("disabled", Disabled);

            base.PreBuild();
        }
    }
}