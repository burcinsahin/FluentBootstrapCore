using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum ButtonState
    {
        [Description(Css.BtnInfo)]
        Default,
        [Description(Css.BtnPrimary)]
        Primary,
        [Description(Css.BtnSuccess)]
        Success,
        [Description(Css.BtnInfo)]
        Info,
        [Description(Css.BtnWarning)]
        Warning,
        [Description(Css.BtnDanger)]
        Danger,
        [Description(Css.BtnLink)]
        Link
    }
}