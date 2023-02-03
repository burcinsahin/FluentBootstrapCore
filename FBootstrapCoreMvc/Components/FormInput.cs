using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class FormInput : FormControl<Input>,
        ICanHaveMaxLength,
        ICanHaveFloatingLabel
    {
        public FormInputType Type { get; set; }
        public int MaxLength { get; set; }
        public bool AutoFocus { get; set; }
        public string? Placeholder { get; set; }
        public string? FloatingLabel { get; set; }

        protected override Input Input => throw new System.NotImplementedException();

        public FormInput(FormInputType inputType = FormInputType.Text, string? label = null)
            : base()
        {
            Label = label;
            Type = inputType;
        }

        protected override void PreBuild()
        {
            AddCss(Css.Mb3);

            if (Readonly)
                MergeAttribute("readonly");

            var input = new Input
            {
                Type = Type,
                Required = Required,
                AutoFocus = AutoFocus,
                MaxLength = MaxLength,
                Name = Name,
                Placeholder = Placeholder,
                Value = Value,
                Content = Content
            };

            input.AddCss(Css.FormControl);
            input.SetId();
            AddChild(input);

            if (Label != null)
            {
                var label = new Label
                {
                    Content = Label,
                    For = input.Id
                };

                label.AddCss(Css.FormLabel);
                AddChild(label, ChildLocation.Header);
            }
            else if (FloatingLabel != null)
            {
                AddCss(Css.FormFloating);

                input.Placeholder = FloatingLabel;
                var label = new Label
                {
                    Content = FloatingLabel,
                    For = input.Id
                };
                AddChild(label);
            }

            base.PreBuild();
        }
    }
}
