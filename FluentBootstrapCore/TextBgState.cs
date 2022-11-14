using System.ComponentModel;

namespace FluentBootstrapCore
{
    public enum TextBgState
    {
        [Description(Css.TextBgLight)]
        Light,
        [Description(Css.TextBgDark)]
        Dark,
        [Description(Css.TextBgSecondary)]
        Secondary,
        [Description(Css.TextBgPrimary)]
        Primary,
        [Description(Css.TextBgSuccess)]
        Success,
        [Description(Css.TextBgInfo)]
        Info,
        [Description(Css.TextBgWarning)]
        Warning,
        [Description(Css.TextBgDanger)]
        Danger
    }
}
