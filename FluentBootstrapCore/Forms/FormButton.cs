using FluentBootstrapCore.Buttons;

namespace FluentBootstrapCore.Forms
{
    // This is like Button except it's derived from FormControl so it includes the form wrapping elements
    public class FormButton : FormControl,
        IHasButtonExtensions, IHasButtonStateExtensions,
        IHasValueAttribute, IHasDisabledAttribute, IHasTextContent, IHasNameAttribute
    {
        internal FormButton(BootstrapHelper helper, ButtonType buttonType)
            : base(helper, "button", Css.Btn, Css.BtnPrimary)
        {
            MergeAttribute("type", buttonType.GetDescription());
        }
    }
}
