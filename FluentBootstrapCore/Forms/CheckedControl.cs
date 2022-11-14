using FluentBootstrapCore.Html;
using Microsoft.AspNetCore.Html;
using System;
using System.IO;
using System.Web;

namespace FluentBootstrapCore.Forms
{
    public class CheckedControl : FormControl, IHasValueAttribute, IHasNameAttribute
    {
        public bool Checked { get; set; }
        public bool Inline { get; set; }
        public string? Description { get; set; }
        public bool SuppressLabelWrapper { get; set; }

        private Element _wrapper = null;
        private Element _label = null;

        internal CheckedControl(BootstrapHelper helper, string type)
            : base(helper, "input", Css.FormCheckInput)
        {
            OutputEndTag = false;
            MergeAttribute("type", type);
        }

        protected override void OnStart(TextWriter writer)
        {
            //Prepare(writer);

            if (Checked)
            {
                MergeAttribute("checked", "checked");
            }

            // Add the description as child content
            if (!string.IsNullOrEmpty(Description))
            {
                AddChild(GetHelper().Content(" " + Description));
            }
            else if (Inline && !SuppressLabelWrapper)
            {
                // Add a space if we're inline without a description
                // This counters the problem of non-labeled checked controls when inline not positioning properly
                // From Bootstrap docs: "Currently only works on non-inline checkboxes and radios."
                AddChild(GetHelper().Content(new HtmlString("&nbsp;")));
            }

            // See if we're in a horizontal form or form group
            var form = GetComponent<Form>();
            var formGroup = GetComponent<FormGroup>();
            var horizontal = form != null && form.Horizontal && (formGroup == null || !formGroup.Horizontal.HasValue || formGroup.Horizontal.Value);

            // Add the wrapper
            if (!Inline)
            {
                var builder = GetHelper().Element("div").AddCss(Css.FormCheck);

                // Hack to make manual padding adjustments if we're horizontal
                if (horizontal)
                {
                    //builder.AddStyle("padding-top", "0");
                }

                _wrapper = builder.Component;
                _wrapper.Start(writer);
            }

            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
            }

            base.OnStart(writer);
            if (Label != null)
            {
                GetHelper().Element("label").SetText(Label.TextContent)
                    .AddCss(Css.FormCheckLabel)
                    .AddAttribute("for", Id)
                    .Component.StartAndFinish(writer);
            }
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            // Finish the wrapper and label
            if (_label != null)
            {
                _label.Finish(writer);
            }
            if (_wrapper != null)
            {
                _wrapper.Finish(writer);
            }
        }
    }
}
