using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum ModalSize
    {
        [Description()]
        Default,
        [Description(Css.ModalSm)]
        Small,
        [Description(Css.ModalLg)]
        Large,
        [Description(Css.ModalXl)]
        XLarge
    }
}