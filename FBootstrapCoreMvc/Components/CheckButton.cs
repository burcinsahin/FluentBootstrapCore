using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class CheckButton : HtmlComponent,
        ICanBeChecked,
        ICanHaveName,
        ICanBeDisabled,
        IButtonOutlineState,
        IButtonState
    {
        public bool Radio { get; set; }
        public bool Checked { get; set; }
        public object? Content { get; set; }
        public string? Name { get; set; }
        public bool Disabled { get; set; }
        public ButtonOutlineState? OutlineState { get; set; }
        public ButtonState ButtonState { get; set; }

        public CheckButton(bool radio = false)
        {
            ButtonState = ButtonState.Primary;
        }

        public override string ToHtml()
        {
            var checkbox = new CheckBox
            {
                Checked = Checked,
                Name = Name,
                Disabled = Disabled,
                AutoComplete = false
            };

            checkbox.AddCss(Css.BtnCheck);
            checkbox.SetId();

            if (Radio)
            {
                checkbox.MergeAttribute("type", "radio");
            }
            else
            {
                checkbox.MergeAttribute("type", "checkbox");
            }

            var label = new Label
            {
                For = checkbox.Id,
                Content = Content
            };
            label.AddCss(Css.Btn, ButtonState.GetCssDescription());

            if (OutlineState.HasValue)
            {
                label.ClearCss();
                label.AddCss(Css.Btn, OutlineState.GetCssDescription());
            }

            return checkbox.ToHtml() + label.ToHtml();
        }
    }
}