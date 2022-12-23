using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Components
{
    public class Input : BaseInput
    {
        public bool Required { get; set; }
        public bool AutoFocus { get; set; }
        public int MaxLength { get; set; }
        public string? Placeholder { get; set; }

        public Input()
            : base(FormInputType.Text)
        {
        }

        protected override void Initialize()
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

            base.Initialize();
        }
    }
}