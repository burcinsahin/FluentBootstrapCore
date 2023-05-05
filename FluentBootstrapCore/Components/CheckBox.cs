using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class CheckBox : InputComponent,
        ICheckedComponent
    {
        public bool Checked { get; set; }
        public string? Role { get; set; }
        public bool Indeterminate { get; set; }
        public bool ToggleButton { get; set; }

        public CheckBox() : base(FormInputType.Checkbox)
        {
        }

        protected override void PreBuild()
        {
            if (Checked)
                MergeAttribute("checked");
            if (Disabled)
                MergeAttribute("disabled");
            if (Role != null)
                MergeAttribute("role", Role);
            if (Indeterminate)
                AddCss("indeterminate");
            base.PreBuild();
        }
    }
}