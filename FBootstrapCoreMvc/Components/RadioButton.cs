using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
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