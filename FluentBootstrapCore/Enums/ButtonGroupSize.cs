using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum ButtonGroupSize
    {
        [Description()]
        Default,
        [Description(Css.BtnGroupLg)]
        Lg,
        [Description(Css.BtnGroupSm)]
        Sm
    }
}
