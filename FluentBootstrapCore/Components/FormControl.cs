using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;
using FluentBootstrapCore.Options;

namespace FluentBootstrapCore.Components
{
    public abstract class FormControl<TComponent> : BootstrapComponent, IFormControl
        where TComponent : BootstrapComponent, IInputComponent
    {
        public bool Readonly { get; set; }
        public bool Disabled { get; set; }
        public string? Label { get; set; }
        public string? Name { get; set; }
        public object? Value { get; set; }
        public bool Required { get; set; }
        public FormControlSize Size { get; set; }
        public bool Invalid { get; set; }

        protected bool _labelFirst;
        internal abstract TComponent Input { get; }

        public OptionList? InputOpts { get; set; }

        protected readonly Label _label;

        public FormControl() : base("div")
        {
            _label = new Label();
            Size = FormControlSize.Default;
        }

        protected override void PreBuild()
        {
            Input.Value = Value;
            Input.Disabled = Disabled;
            Input.Readonly = Readonly;
            Input.Name = Name;
            Input.Required = Required;
            if (Id != null)
            {
                Input.Id = Id;
                Id = null;
            }
            else
                Input.GenerateId();

            if (InputOpts != null)
                Input.UtilityOptions = InputOpts;

            if (Size != FormControlSize.Default)
                Input.AddCss(Size.GetCssDescription());
            if (Invalid)
                Input.AddCss(Css.IsInvalid);
            if (Label != null)
            {
                _label.AddCss(Css.FormLabel);
                _label.Content = Label;
                _label.For = Input.Id;
                if (_labelFirst)
                    AddChild(_label);
            }

            AddChild(Input);

            if (Label != null && !_labelFirst)
                AddChild(_label);

            base.PreBuild();
        }
    }
}