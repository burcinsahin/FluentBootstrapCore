using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class RadioButton : InputComponent,
        ICanBeChecked
    {
        public bool Checked { get; set; }

        public RadioButton() : base(FormInputType.Radio)
        {
        }

        protected override void PreBuild()
        {
            if (Checked)
                MergeAttribute("checked");

            base.PreBuild();
        }
    }
}