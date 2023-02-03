using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Components
{
    public class Input : InputComponent
    {
        public bool AutoFocus { get; set; }
        public int MaxLength { get; set; }

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

            base.PreBuild();
        }
    }
}