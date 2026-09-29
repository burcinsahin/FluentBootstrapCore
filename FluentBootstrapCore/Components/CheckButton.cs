using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class CheckButton(bool radio = false) : HtmlComponent,
        ICanBeChecked,
        ICanHaveName,
        ICanBeDisabled,
        IButtonOutlineState,
        IButtonState
    {
        public bool Radio { get; set; } = radio;
        public bool Checked { get; set; }
        public object? Content { get; set; }
        public string? Name { get; set; }
        public bool Disabled { get; set; }
        public ButtonOutlineState? OutlineState { get; set; }
        public ButtonState ButtonState { get; set; } = ButtonState.Primary;

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
            checkbox.GenerateId();

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