using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum FormSelectSize
    {
        [Description()]
        Default,
        [Description(Css.FormSelectLg)]
        Lg,
        [Description(Css.FormSelectSm)]
        Sm
    }
}