using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;

namespace FBootstrapCoreMvc.Components
{
    public class FormInput : HtmlComponent
    {
        private Input _input;
        private Label _label;

        public FormInput(FormInputType inputType = FormInputType.Text, string? label = null)
            : base("div", Css.Mb3)
        {
            _input = new Input();
            _input.AddCss(Css.FormControl);
            _input.SetType(inputType);
            _input.SetId();

            _label = new Label();
            if (label != null)
            {
                _label.AddCss(Css.FormLabel);
                _label.MergeAttribute("for", _input.Id);
                _label.SetContent(label);

                AddChild(_label);
            }
            AddChild(_input);
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
            _label.MergeAttribute("for", _input.Id);
            _label.SetContent(label);

            RemoveChild(_label);
            AddChild(_label);
            return this;
        }

        public FormInput SetReadonly()
        {
            _input.MergeAttribute("readonly", true);
            return this;
        }
    }
}
