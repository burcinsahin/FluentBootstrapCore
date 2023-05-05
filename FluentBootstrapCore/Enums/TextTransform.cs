using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum TextTransform
    {
        [Description(Css.TextLowercase)]
        Lowercase,
        [Description(Css.TextUppercase)]
        Uppercase,
        [Description(Css.TextCapitalize)]
        Capitalize
    }
}
