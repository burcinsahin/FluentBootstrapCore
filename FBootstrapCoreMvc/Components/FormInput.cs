using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class FormInput : Component<FormInput>
    {
        private Input _input;
        private Label _label;

        public FormInput(IHtmlHelper helper, FormInputType inputType = FormInputType.Text, string? label = null)
            : base(helper, "div", Css.Mb3)
        {
            _input = new Input(helper)
                .AddCss(Css.FormControl)
                .SetType(inputType)
                .SetId();

            _label = new Label(helper);
            if (label != null)
            {
                _label.AddCss(Css.FormLabel)
                .AddAttribute("for", _input.Id)
                .SetContent(label);

                _childComponents.Add(_label);
            }

            _childComponents.Add(_input);

            AppendChildrenToHtml();
        }

        public FormInput IsRequired()
        {
            _input.IsRequired();
            return this;
        }

        public FormInput AutoFocus()
        {
            _input.AutoFocus();
            return this;
        }

        public FormInput SetMaxLength(short value = 100)
        {
            _input.SetMaxLength(value);
            return this;
        }

        public FormInput SetPlaceholder(string? text)
        {
            _input.SetPlaceholder(text);
            return this;
        }

        public FormInput SetName(string? text)
        {
            _input.SetName(text);
            return this;
        }

        public FormInput SetValue(object? value)
        {
            _input.SetValue(value);
            return this;
        }

        public FormInput SetType(FormInputType inputType)
        {
            _input.SetType(inputType);
            return this;
        }

        public FormInput SetFloatingLabel(string? label)
        {
            AddCss(Css.FormFloating);
            _input.SetPlaceholder(label);
            _label.AddAttribute("for", _input.Id).SetContent(label);
            _childComponents.Remove(_label);
            _childComponents.Add(_label);
            AppendChildrenToHtml(true);
            return this;
        }

        public FormInput SetReadonly()
        {
            _input.AddAttribute("readonly", true);
            return this;
        }
    }
}
