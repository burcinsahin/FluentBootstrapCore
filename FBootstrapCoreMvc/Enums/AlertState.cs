using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum AlertState
    {
        [Description(Css.AlertSuccess)]
        Success,
        [Description(Css.AlertInfo)]
        Info,
        [Description(Css.AlertWarning)]
        Warning,
        [Description(Css.AlertDanger)]
        Danger,
        [Description(Css.AlertPrimary)]
        Primary,
        [Description(Css.AlertSecondary)]
        Secondary,
        [Description(Css.AlertLight)]
        Light,
        [Description(Css.AlertDark)]
        Dark
    }
}
