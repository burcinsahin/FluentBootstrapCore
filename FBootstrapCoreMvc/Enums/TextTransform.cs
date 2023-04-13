using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
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
