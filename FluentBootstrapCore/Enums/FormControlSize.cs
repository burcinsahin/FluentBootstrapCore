using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum FormControlSize
    {
        [Description()]
        Default,
        [Description(Css.FormControlLg)]
        Lg,
        [Description(Css.FormControlSm)]
        Sm
    }
}