using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum TextBgState
    {
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
