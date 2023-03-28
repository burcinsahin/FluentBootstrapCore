using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class FormRadio : FormControl<RadioButton>,
        ICheckedComponent,
        ICanBeInline
    {
        public bool Checked { get; set; }
        public bool Inline { get; set; }
        public bool ToggleButton { get; set; }
        public bool Reverse { get; set; }

        private readonly RadioButton _radioButton;
        internal override RadioButton Input => _radioButton;

        public FormRadio(string? label)
            : base()
        {
            Label = label;
            _radioButton = new RadioButton();
        }

        protected override void PreBuild()
        {
            AddCss(Css.FormCheck);
            
            if (Inline)
                AddCss(Css.FormCheckInline);

            _radioButton.AddCss(Css.FormCheckInput);
            _radioButton.Checked = Checked;

            _label.AddCss(Css.FormCheckLabel);

            base.PreBuild();
        }
    }
}