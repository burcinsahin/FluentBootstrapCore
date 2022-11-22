using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class RadioButton : HtmlComponent,
        ICanHaveName, ICanBeDisabled
    {
        public RadioButton()
            : base("input", Css.FormCheckInput)
        {
            MergeAttribute("type", "radio");
        }
    }
}