using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum LineHeight
    {
        [Description(Css.Lh1)]
        _1,
        [Description(Css.LhSm)]
        Small,
        [Description(Css.LhBase)]
        Base,
        [Description(Css.LhLg)]
        Large
    }
}