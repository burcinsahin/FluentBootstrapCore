using System.ComponentModel;

namespace FluentBootstrapCore
{
    public enum ButtonGroupSize
    {
        [Description()]
        Default,
        [Description(Css.BtnGroupLg)]
        Lg,
        [Description(Css.BtnGroupSm)]
        Sm,
        [Description(Css.BtnGroupSm)]
        Xs
    }
}
