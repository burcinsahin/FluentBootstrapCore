using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum BgColor
    {
        [Description()]
        None,
        [Description(Css.BgPrimary)]
        Primary,
        [Description(Css.BgSecondary)]
        Secondary,
        [Description(Css.BgSuccess)]
        Success,
        [Description(Css.BgInfo)]
        Info,
        [Description(Css.BgWarning)]
        Warning,
        [Description(Css.BgDanger)]
        Danger,
        [Description(Css.BgLight)]
        Light,
        [Description(Css.BgDark)]
        Dark,
        [Description(Css.BgBody)]
        Body,
        [Description(Css.BgWhite)]
        White,
        [Description(Css.BgTransparent)]
        Transparent
    }
}
