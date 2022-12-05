using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class RadioButton : BaseInput,
        ICanBeChecked
    {
        public RadioButton() : base(FormInputType.Radio)
        {
        }
    }
}