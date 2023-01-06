using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum ButtonOutlineState
    {
        [Description(Css.BtnOutlinePrimary)]
        Primary,
        [Description(Css.BtnOutlineSecondary)]
        Secondary,
        [Description(Css.BtnOutlineSuccess)]
        Success,
        [Description(Css.BtnOutlineInfo)]
        Info,
        [Description(Css.BtnOutlineWarning)]
        Warning,
        [Description(Css.BtnOutlineDanger)]
        Danger,
        [Description(Css.BtnOutlineLight)]
        Light,
        [Description(Css.BtnOutlineDark)]
        Dark
    }
}