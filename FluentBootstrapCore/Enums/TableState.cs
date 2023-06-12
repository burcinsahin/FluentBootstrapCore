using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum TableState
    {
        [Description(Css.TablePrimary)]
        Primary,
        [Description(Css.TableSecondary)]
        Secondary,
        [Description(Css.TableSuccess)]
        Success,
        [Description(Css.TableDanger)]
        Danger,
        [Description(Css.TableWarning)]
        Warning,
        [Description(Css.TableInfo)]
        Info,
        [Description(Css.TableLight)]
        Light,
        [Description(Css.TableDark)]
        Dark
    }
}