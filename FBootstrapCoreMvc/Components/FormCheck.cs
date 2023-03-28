using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class FormCheck : FormControl<CheckBox>,
        ICheckedComponent,
        ICanBeReverse,
        ICanBeInline
    {
        public bool Checked { get; set; }
        public bool Inline { get; set; }
        public bool Switch { get; set; }
        public bool Indeterminate { get; set; }
        public bool Reverse { get; set; }
        internal override CheckBox Input => _checkBox;

        private readonly CheckBox _checkBox;

        public FormCheck()
            : base()
        {
            _checkBox = new CheckBox();
        }

        protected override void PreBuild()
        {
            AddCss(Css.FormCheck);
            Value = true;

            if (Inline)
                AddCss(Css.FormCheckInline);

            if (Switch)
            {
                AddCss(Css.FormSwitch);
                _checkBox.Role = "switch";
            }
            if (Reverse)
                AddCss(Css.FormCheckReverse);

            _checkBox.AddCss(Css.FormCheckInput);
            _checkBox.Checked = Checked;
            _checkBox.Indeterminate = Indeterminate;

            _label.AddCss(Css.FormCheckLabel);

            var hidden = new Hidden
            {
                Value = false,
                Name = Name
            };
            AddChild(hidden, ChildLocation.Footer);

            base.PreBuild();
        }
    }
}