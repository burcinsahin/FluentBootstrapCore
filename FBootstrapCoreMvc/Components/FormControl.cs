using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public abstract class FormControl : HtmlComponent,
        ICanBeReadonly,
        ICanHaveFloatingLabel,
        ICanHaveLabel
    {
        public bool Readonly { get; set; }
        public string? FloatingLabel { get; set; }
        public string? Label { get; set; }
        public string? Name { get; set; }
        public object? Value { get; set; }

        protected HtmlComponent? _inputComponent;

        public FormControl() : base("div", Css.Mb3)
        {
        }

        protected override void PreBuild()
        {
            if (_inputComponent != null) 
            {
                //TODO: implement common behaviors
            }


            base.PreBuild();
        }
    }
}