using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class FormTextArea : FormControl<TextArea>,
        ICanHaveMaxLength,
        ICanHaveFloatingLabel,
        IPlaceholder
    {
        public string? Placeholder { get; set; }
        public int MaxLength { get; set; }
        public string? FloatingLabel { get; set; }

        protected override TextArea Input => throw new System.NotImplementedException();

        protected override void PreBuild()
        {
            var textarea = new TextArea();
            textarea.AddCss(Css.FormControl);
            textarea.SetId();
            if (Name != null)
                textarea.Name = Name;
            if (Value != null)
                textarea.Value = Value;
            if (Placeholder != null)
                textarea.Placeholder = Placeholder;
            if (MaxLength > 0)
                textarea.MaxLength = MaxLength;
            textarea.Content = Content;
            Content = null;
            AddChild(textarea);

            if (Label != null)
            {
                var label = new Label()
                {
                    Content = Label
                };
                label.AddCss(Css.FormLabel);
                label.For = textarea.Id;
                AddChild(label, ChildLocation.Header);
            }
            else if (FloatingLabel != null)
            {
                AddCss(Css.FormFloating);
                var label = new Label()
                {
                    Content = FloatingLabel,
                    For = textarea.Id
                };
                textarea.MergeAttribute("placeholder", FloatingLabel);
                AddChild(label, ChildLocation.Footer);
            }

            base.PreBuild();
        }
    }
}
