using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class TextArea : SingleComponent,
        IInput,
        ICanHaveMaxLength,
        IPlaceholder
    {
        public object? Value { get; set; }
        public string? Name { get; set; }
        public bool Disabled { get; set; }
        public bool Required { get; set; }
        public int MaxLength { get; set; }
        public string? Placeholder { get; set; }

        public TextArea() : base("textarea")
        {
        }
    }
}
