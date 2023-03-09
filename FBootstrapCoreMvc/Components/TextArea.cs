using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class TextArea : SingleComponent,
        IInputComponent,
        ICanHaveMaxLength,
        IPlaceholder,
        ICanHaveHeight
    {
        public object? Value { get; set; }
        public string? Name { get; set; }
        public bool Disabled { get; set; }
        public bool Required { get; set; }
        public int MaxLength { get; set; }
        public string? Placeholder { get; set; }
        public short Rows { get; set; }
        public bool AutoFocus { get; set; }
        public bool Readonly { get; set; }
        public short Height { get; set; }

        public TextArea() : base("textarea")
        {
        }

        protected override void PreBuild()
        {
            if (Rows > 0)
                MergeAttribute("rows", Rows);
            if (Height > 0)
                MergeStyle("height", $"{Height}px");
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
            if (Readonly)
                MergeAttribute("readonly");
            if (Disabled)
                MergeAttribute("disabled");
            base.PreBuild();
        }
    }
}
