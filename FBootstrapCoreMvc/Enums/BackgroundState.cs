using FBootstrapCoreMvc;
using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum BackgroundState
    {
        [Description(Css.BgPrimary)]
        Primary,
        [Description(Css.BgSuccess)]
        Success,
        [Description(Css.BgInfo)]
        Info,
        [Description(Css.BgWarning)]
        Warning,
        [Description(Css.BgDanger)]
        Danger
    }
}
