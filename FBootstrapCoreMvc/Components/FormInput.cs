﻿using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class FormInput : FormControl<Input>,
        ICanHaveMaxLength,
        ICanHaveFloatingLabel,
        IPlaceholder,
        ICanHaveTitle
    {
        public FormInputType Type { get; set; }
        public int MaxLength { get; set; }
        public bool AutoFocus { get; set; }
        public string? Placeholder { get; set; }
        public string? FloatingLabel { get; set; }
        public bool PlainText { get; set; }
        public bool Multiple { get; set; }
        public string? Title { get; set; }

        private readonly Input _input;
        protected override Input Input => _input;


        public FormInput(FormInputType inputType = FormInputType.Text, string? label = null)
            : base()
        {
            _input = new Input();
            _labelFirst = true;
            Label = label;
            Type = inputType;
        }

        protected override void PreBuild()
        {
            AddCss(Css.Mb3);

            if (Readonly)
                MergeAttribute("readonly");

            _input.Type = Type;
            _input.MaxLength = MaxLength;
            _input.AutoFocus = AutoFocus;
            _input.Name = Name;
            _input.Placeholder = Placeholder;
            _input.Value = Value;
            _input.Content = Content;
            _input.Required = Required;
            _input.Multiple = Multiple;
            _input.Title = Title;
            _input.AddCss(Css.FormControl);
            _input.SetId();

            if (Type == FormInputType.Color)
                _input.AddCss(Css.FormControlColor);

            if (PlainText)
            {
                _input.RemoveCss(Css.FormControl);
                _input.AddCss(Css.FormControlPlaintext);
            }

            if (FloatingLabel != null)
            {
                _label.ClearCss();
                _label.AddCss(Css.FormFloating);
                _input.Placeholder = FloatingLabel;
                _labelFirst = false;
            }

            base.PreBuild();
        }
    }
}
