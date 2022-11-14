using FluentBootstrapCore.Buttons;

namespace FluentBootstrapCore.Forms
{
    public class InputButton : FormControl,
        IHasButtonExtensions, IHasButtonStateExtensions, IHasDisabledAttribute,
        IHasValueAttribute, IHasNameAttribute
    {
        internal InputButton(BootstrapHelper helper, ButtonType buttonType)
            : base(helper, "input", Css.Btn, Css.BtnPrimary)
        {
            OutputEndTag = false;
            MergeAttribute("type", buttonType.GetDescription());
        }
    }
}
