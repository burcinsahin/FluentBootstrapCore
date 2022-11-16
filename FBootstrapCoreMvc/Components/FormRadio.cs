using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class FormRadio : Component<FormRadio>
    {
        private readonly Label _label;
        private readonly RadioButton _radioButton;

        public FormRadio(IHtmlHelper helper, string? name, string? label, bool value = false)
            : base(helper, "div", Css.FormCheck)
        {
            _radioButton = new RadioButton(helper)
                .AddCss(Css.FormCheckInput)
                .SetId()
                .AddAttribute("checked", value)
                .SetName(name);
            _label = new Label(helper)
                .AddCss(Css.FormCheckLabel)
                .AddAttribute("for", _radioButton.Id)
                .SetContent(label);

            _childComponents.Add(_radioButton);
            _childComponents.Add(_label);
            AppendChildrenToHtml();
        }

        public FormRadio SetReadonly()
        {
            _radioButton.SetDisabled(true);
            AppendChildrenToHtml(true);
            return this;
        }
    }
}