using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum InputGroupSize
    {
        [Description]
        Default,
        [Description(Css.InputGroupLg)]
        Lg,
        [Description(Css.InputGroupSm)]
        Sm
    }
}
