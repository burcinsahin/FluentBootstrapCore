using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum ButtonSize
    {
        [Description()]
        Default,
        [Description(Css.BtnLg)]
        Large,
        [Description(Css.BtnSm)]
        Small
    }
}
