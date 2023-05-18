using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Input : InputComponent, ICanHaveTitle
    {
        public bool AutoFocus { get; set; }
        public int MaxLength { get; set; }
        public bool Multiple { get; set; }
        public string? Title { get; set; }

        public Input()
            : base(FormInputType.Text)
        {
        }

        protected override void PreBuild()
        {
            if (Required)
                MergeAttribute("required", true);
            if (AutoFocus)
                MergeAttribute("autofocus", true);
            if (MaxLength > 0)
                MergeAttribute("maxlength", MaxLength);
            if (Placeholder != null)
                MergeAttribute("placeholder", Placeholder);
            if (Name != null)
                MergeAttribute("name", Name);
            if (Multiple)
                MergeAttribute("multiple");
            if (Title != null)
                MergeAttribute("title", Title);

            if (HasParent<Form>(false))
                AddCss(Css.FormControl);

            base.PreBuild();
        }
    }
}