using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum ButtonState
    {
        [Description(Css.BtnPrimary)]
        Primary,
        [Description(Css.BtnSecondary)]
        Secondary,
        [Description(Css.BtnSuccess)]
        Success,
        [Description(Css.BtnInfo)]
        Info,
        [Description(Css.BtnWarning)]
        Warning,
        [Description(Css.BtnDanger)]
        Danger,
        [Description(Css.BtnLight)]
        Light,
        [Description(Css.BtnDark)]
        Dark,
        [Description(Css.BtnLink)]
        Link
    }
}