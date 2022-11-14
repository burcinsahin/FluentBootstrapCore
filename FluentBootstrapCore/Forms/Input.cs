using System.IO;

namespace FluentBootstrapCore.Forms
{
    public class Input
        : FormControl, IHasValueAttribute, IHasNameAttribute,
            IHasRequiredAttribute, IHasMaxLengthAttribute
    {
        public Icon Icon { get; set; }

        internal Input(BootstrapHelper helper, FormInputType inputType)
            : base(helper, "input", Css.FormControl)
        {
            OutputEndTag = false;
            Icon = Icon.None;
            MergeAttribute("type", inputType.GetDescription());
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Add the feedback icon
            if (Icon != Icon.None)
            {
                //GetHelper().Icon(Icon).AddCss(Css.FormControlFeedback).Component.StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }
}
