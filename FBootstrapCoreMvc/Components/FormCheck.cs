using FBootstrapCoreMvc.Extensions;

namespace FBootstrapCoreMvc.Components
{
    public class FormCheck : HtmlComponent,
        ICanBeReadonly
    {
        private readonly Label _label;
        private readonly CheckBox _checkbox;
        private readonly Hidden _hidden;

        public bool Readonly { get; set; }

        public FormCheck(string? name, string? label, bool? value = false)
            : base("div", Css.FormCheck)
        {
            _checkbox = new CheckBox();
            _checkbox.AddCss(Css.FormCheckInput);
            _checkbox.SetId();
            _checkbox.SetValue(true);
            _checkbox.SetChecked(value);
            _checkbox.SetName(name);

            _label = new Label();
            _label.AddCss(Css.FormCheckLabel);
            _label.MergeAttribute("for", _checkbox.Id);
            _label.SetContent(label);
            _hidden = new Hidden();
            _hidden.SetValue(false);
            _hidden.SetName(name);
            AddChild(_checkbox);
            AddChild(_label);
            AddChild(_hidden);
        }

        protected override void Initialize()
        {
            if (Readonly)
                _checkbox.SetDisabled();
            base.Initialize();
        }

        protected internal FormCheck SetReadonly()
        {
            _checkbox.SetDisabled(true);
            return this;
        }

        protected internal FormCheck SetInline()
        {
            AddCss(Css.FormCheckInline);
            return this;
        }
    }
}