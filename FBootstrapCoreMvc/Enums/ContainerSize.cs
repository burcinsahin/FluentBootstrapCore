using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum ContainerSize
    {
        [Description(Css.ContainerSm)]
        Small,
        [Description(Css.ContainerMd)]
        Medium,
        [Description(Css.ContainerLg)]
        Large,
        [Description(Css.ContainerXl)]
        XLarge,
        [Description(Css.ContainerXxl)]
        XXLarge
    }
}