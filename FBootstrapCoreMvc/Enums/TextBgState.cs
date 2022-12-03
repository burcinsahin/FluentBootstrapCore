using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum TextBgState
    {
        [Description(Css.TextBgPrimary)]
        Primary,
        [Description(Css.TextBgSecondary)]
        Secondary,
        [Description(Css.TextBgSuccess)]
        Success,
        [Description(Css.TextBgDanger)]
        Danger,
        [Description(Css.TextBgWarning)]
        Warning,
        [Description(Css.TextBgInfo)]
        Info,
        [Description(Css.TextBgLight)]
        Light,
        [Description(Css.TextBgDark)]
        Dark
    }
}
