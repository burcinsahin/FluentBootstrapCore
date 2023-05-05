using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class SelectOption : BootstrapComponent,
        ICanHaveValue,
        ICanBeDisabled,
        ICanBeSelected
    {
        public bool Disabled { get; set; }
        public object? Value { get; set; }
        public bool Selected { get; set; }
        public SelectOption()
            : base("option")
        { }

        protected override void PreBuild()
        {
            if (Value != null)
                MergeAttribute("value", Value);

            if (Selected)
                MergeAttribute("selected");

            base.PreBuild();
        }
    }
}