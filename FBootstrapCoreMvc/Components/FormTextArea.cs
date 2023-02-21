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

        public short Rows { get; set; }
        private readonly TextArea _textArea;

        public FormTextArea()
        {
            _textArea = new TextArea();
            _labelFirst = true;
        }

        protected override TextArea Input => _textArea;

        protected override void PreBuild()
        {
            _textArea.AddCss(Css.FormControl);
            _textArea.SetId();
            _textArea.Name = Name;
            _textArea.Value = Value;
            _textArea.Placeholder = Placeholder;
            _textArea.MaxLength = MaxLength;
            _textArea.Content = Content;
            _textArea.Rows = Rows;
            Content = null;

            if (FloatingLabel != null)
            {
                _labelFirst = false;
                AddCss(Css.FormFloating);
                _label.Content = FloatingLabel;
                _label.For = _textArea.Id;
                _textArea.Placeholder = FloatingLabel;
            }

            base.PreBuild();
        }
    }
}
