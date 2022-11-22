using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class FormRadio : HtmlComponent
    {
        private readonly Label _label;
        private readonly RadioButton _radioButton;

        public FormRadio(string? name, string? label, bool value = false)
            : base("div", Css.FormCheck)
        {
            _radioButton = new RadioButton();
            _radioButton.AddCss(Css.FormCheckInput);
            _radioButton.SetId();
            _radioButton.MergeAttribute("checked", value);
            _radioButton.SetName(name);
            _label = new Label();
            _label.AddCss(Css.FormCheckLabel);
            _label.AddAttribute("for", _radioButton.Id);
            _label.SetContent(label);

            AddChild(_radioButton);
            AddChild(_label);
        }

        public FormRadio SetReadonly()
        {
            _radioButton.SetDisabled(true);
            return this;
        }
    }
}