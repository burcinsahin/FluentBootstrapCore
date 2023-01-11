using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class RadioButton : BaseInput,
        ICanBeChecked
    {
        public bool Checked { get; set; }

        public RadioButton() : base(FormInputType.Radio)
        {
        }
    }
}