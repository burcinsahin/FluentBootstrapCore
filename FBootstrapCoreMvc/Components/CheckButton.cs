using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class CheckButton : HtmlComponent,
        ICanBeChecked,
        ICanHaveName
    {
        public bool Radio { get; set; }
        public bool Checked { get; set; }
        public object? Content { get; set; }
        public string? Name { get; set; }

        public override string ToHtml()
        {
            var input = new HtmlElement("input");
            input.AddCss(Css.BtnCheck);
            input.MergeAttribute("autocomplete", "off");
            input.SetId();

            if (Checked)
                input.MergeAttribute("checked");

            if (Name != null)
                input.MergeAttribute("name", Name);

            if (Radio)
            {
                input.MergeAttribute("type", "radio");
            }
            else
            {
                input.MergeAttribute("type", "checkbox");
            }

            var label = new HtmlElement("label");
            label.AddCss(Css.Btn, Css.BtnOutlinePrimary);
            label.MergeAttribute("for", input.Id);
            label.AppendContent(Content);

            return input.ToHtml() + label.ToHtml();
        }
    }
}