using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;

namespace FBootstrapCoreMvc.Components
{
    public class FormInput : FormControl, ICanHaveMaxLength
    {
        public FormInputType Type { get; set; }
        public bool Required { get; set; }
        public int MaxLength { get; set; }
        public bool AutoFocus { get; set; }
        public string? Placeholder { get; set; }

        public FormInput(FormInputType inputType = FormInputType.Text, string? label = null)
            : base()
        {
            Label = label;
            Type = inputType;
        }

        protected override void PreBuild()
        {
            if (Readonly)
                MergeAttribute("readonly");

            var input = new Input
            {
                Type = Type
            };

            input.AddCss(Css.FormControl);
            input.SetId();

            input.Required = Required;
            input.AutoFocus = AutoFocus;
            input.MaxLength = MaxLength;
            input.Name = Name;
            input.Placeholder = Placeholder;

            AddChild(input);

            if (Label != null)
            {
                var label = new Label()
                {
                    Content = Label
                };
                label.AddCss(Css.FormLabel);
                label.For = input.Id;
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
