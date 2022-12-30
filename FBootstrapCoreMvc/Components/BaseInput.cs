using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public abstract class BaseInput : HtmlComponent,
        ICanHaveValue,
        ICanHaveName,
        ICanBeDisabled
    {
        public FormInputType Type { get; set; }
        public object? Value { get; internal set; }
        public string? Name { get; set; }
        public bool Disabled { get; set; }

        public BaseInput(FormInputType inputType, params string[] cssClasses)
            : base("input", cssClasses)
        {
            Type = inputType;
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
            base.PreBuild();
        }
    }
}
