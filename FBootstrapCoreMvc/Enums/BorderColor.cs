using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum BorderColor
    {
        [Description()]
        None,
        [Description(Css.BorderPrimary)]
        Primary,
        [Description(Css.BorderSecondary)]
        Secondary,
        [Description(Css.BorderSuccess)]
        Success,
        [Description(Css.BorderInfo)]
        Info,
        [Description(Css.BorderWarning)]
        Warning,
        [Description(Css.BorderDanger)]
        Danger,
        [Description(Css.BorderLight)]
        Light,
        [Description(Css.BorderDark)]
        Dark,
        [Description(Css.BorderWhite)]
        White
    }

}