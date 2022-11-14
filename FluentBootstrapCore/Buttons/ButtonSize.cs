using System.ComponentModel;

namespace FluentBootstrapCore
{
    public enum ButtonSize
    {
        [Description()]
        Default,
        [Description(Css.BtnLg)]
        Lg,
        [Description(Css.BtnSm)]
        Sm,
        [Description(Css.BtnSm)]
        Xs
    }
}
