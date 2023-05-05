using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum Shadow
    {
        [Description(Css.ShadowNone)]
        None,
        [Description(Css.ShadowSm)]
        Small,
        [Description(Css.Shadow)]
        Medium,
        [Description(Css.ShadowLg)]
        Large,
    }
}
