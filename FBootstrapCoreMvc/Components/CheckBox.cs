using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class CheckBox : BaseInput,
        ICanBeDisabled,
        ICanHaveName,
        ICanHaveValue,
        ICanBeChecked
    {
        public CheckBox() : base(FormInputType.Checkbox)
        {
        }

        protected internal void SetChecked(bool? value = false)
        {
            if (value == null || value.Value)
                MergeAttribute("checked");
        }
    }
}