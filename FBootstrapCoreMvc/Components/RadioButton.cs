using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class RadioButton : Component<RadioButton>,
        ICanHaveName, ICanBeDisabled
    {
        public RadioButton(IHtmlHelper helper)
            : base(helper, "input", Css.FormCheckInput)
        {
            MergeAttribute("type", "radio");
        }
    }
}