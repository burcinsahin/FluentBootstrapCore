using FBootstrapCoreMvc.Extensions;

namespace FBootstrapCoreMvc.Components
{
    public class FormTextArea : FormControl,
        ICanHaveMaxLength
    {
        public string? Placeholder { get; set; }
        public int MaxLength { get; set; }

        protected override void PreBuild()
        {
            var textarea = new HtmlElement("textarea", Css.FormControl);
            textarea.SetId();
            if (Name != null)
                textarea.MergeAttribute("name", Name);
            if (Value != null)
                textarea.MergeAttribute("value", Value);
            if (Placeholder != null)
                textarea.MergeAttribute("placeholder", Placeholder);
            if (MaxLength > 0)
                textarea.MergeAttribute("maxlength", MaxLength);
            textarea.Content = Content;
            Content = null;
            AddChild(textarea);

            if (FloatingLabel != null)
            {
                AddCss(Css.FormFloating);
                var label = new Label()
                {
                    Content = FloatingLabel,
                    For = textarea.Id
                };

                AddChild(label);
            }

            base.PreBuild();
        }

    }
}
