using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class CheckBox : Component<CheckBox>,
        ICanBeDisabled, ICanHaveName, ICanHaveValue
    {
        public CheckBox(IHtmlHelper helper)
            : base(helper, "input")
        {
            AddAttribute("type", "checkbox");
        }

        public CheckBox SetChecked(bool? value = null)
        {
            if (!value.HasValue || value.Value)
                return AddAttribute("checked");
            return this;
        }
    }
}