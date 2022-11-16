using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class FormCheck : Component<FormCheck>
    {
        private readonly Label _label;
        private readonly CheckBox _checkbox;
        private readonly Hidden _hidden;
        public FormCheck(IHtmlHelper helper, string? name, string? label, bool? value = false)
            : base(helper, "div", Css.FormCheck)
        {
            _checkbox = new CheckBox(helper)
                .AddCss(Css.FormCheckInput)
                .SetId()
                .SetValue(true)
                .SetChecked(value)
                .SetName(name);
            _label = new Label(helper)
                .AddCss(Css.FormCheckLabel)
                .AddAttribute("for", _checkbox.Id)
                .SetContent(label);
            _hidden = new Hidden(helper)
                .SetValue(false)
                .SetName(name);
            _childComponents.Add(_checkbox);
            _childComponents.Add(_label);
            _childComponents.Add(_hidden);
            AppendChildrenToHtml();
        }

        public FormCheck SetReadonly()
        {
            _checkbox.SetDisabled(true);
            AppendChildrenToHtml(true);
            return this;
        }

        public FormCheck SetInline() => AddCss(Css.FormCheckInline);
    }
}