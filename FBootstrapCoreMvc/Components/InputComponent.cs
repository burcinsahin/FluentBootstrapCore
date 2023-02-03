using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public abstract class InputComponent : SingleComponent, 
        IInput,
        IPlaceholder
    {
        public FormInputType Type { get; set; }
        public object? Value { get; set; }
        public string? Name { get; set; }
        public bool Disabled { get; set; }
        public string? Placeholder { get; set; }
        public bool Required { get; set; }
        public bool AutoComplete { get; set; }
        public InputComponent(FormInputType inputType, params string[] cssClasses)
            : base("input", cssClasses)
        {
            Type = inputType;
            AutoComplete = true;
        }

        protected override void PreBuild()
        {
            MergeAttribute("type", Type.GetDescription());
            if (Value != null)
                MergeAttribute("value", Value);
            if (Name != null)
                MergeAttribute("name", Name);
            if (Disabled)
                MergeAttribute("disabled");
            if (!AutoComplete)
                MergeAttribute("autocomplete", "off");
            base.PreBuild();
        }
    }
}
