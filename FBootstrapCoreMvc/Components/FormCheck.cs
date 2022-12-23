using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class FormCheck : FormControl,
        ICanBeReadonly,
        ICanHaveLabel
    {
        public bool Checked { get; set; }
        public bool Inline { get; set; }
        public FormCheck()
            : base()
        {
            AddCss(Css.FormCheck);
        }

        protected override void PreBuild()
        {
            var checkbox = new CheckBox();
            checkbox.AddCss(Css.FormCheckInput);
            checkbox.SetId();
            checkbox.Value = true;
            checkbox.Checked = Checked;
            checkbox.Name = Name;

            if (Readonly)
                checkbox.Disabled = true;

            if (Inline)
                AddCss(Css.FormCheckInline);

            AddChild(checkbox);

            if (Label != null)
            {
                var label = new Label
                {
                    Content = Label
                };
                label.AddCss(Css.FormCheckLabel);
                label.For = checkbox.Id;
                AddChild(label);
            }
            var hidden = new Hidden
            {
                Value = false,
                Name = Name
            };
            AddChild(hidden);

            base.PreBuild();
        }
    }
}