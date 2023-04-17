using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum LinkColor
    {
        [Description(Css.LinkPrimary)]
        Primary,
        [Description(Css.LinkSecondary)]
        Secondary,
        [Description(Css.LinkSuccess)]
        Success,
        [Description(Css.LinkInfo)]
        Info,
        [Description(Css.LinkWarning)]
        Warning,
        [Description(Css.LinkDanger)]
        Danger,
        [Description(Css.LinkLight)]
        Light,
        [Description(Css.LinkDark)]
        Dark
    }
}