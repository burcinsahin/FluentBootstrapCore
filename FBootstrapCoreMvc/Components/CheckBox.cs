using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class CheckBox : HtmlComponent,
        ICanBeDisabled, ICanHaveName, ICanHaveValue
    {
        public CheckBox()
            : base("input")
        {
            MergeAttribute("type", "checkbox");
        }

        protected internal void SetChecked(bool? value = false)
        {
            if (value == null || value.Value)
                MergeAttribute("checked");
        }
    }
}