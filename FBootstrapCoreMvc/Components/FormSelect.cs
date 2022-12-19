using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Components
{
    public class FormSelect : HtmlComponent
    {
        public string? LabelText { get; set; }
        public string? Name { get; set; }
        public IEnumerable<SelectListItem>? SelectList { get; set; }
        public object? SelectedValue { get; internal set; }

        public FormSelect(string? label = null)
            : base("div")
        {
            LabelText = label;
        }

        protected override void Initialize()
        {
            var select = new Select().SetId();

            if (Name != null)
                select.MergeAttribute("name", Name);

            select.SelectList = SelectList;
            select.SelectedValue = SelectedValue;

            AddChild(select);

            if (LabelText != null)
            {
                AddCss(Css.FormFloating);
                var label = new Label();
                label.SetContent(LabelText);
                label.MergeAttribute("for", select.Id);
                AddChild(label);
            }

            base.Initialize();
        }
    }
}