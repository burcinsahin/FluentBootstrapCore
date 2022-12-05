using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum BackgroundState
    {
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
        Dark
    }
}
