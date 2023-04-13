using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum TextDecoration
    {
        [Description(Css.TextDecorationUnderline)]
        Underline,
        [Description(Css.TextDecorationLineThrough)]
        LineThrough,
        [Description(Css.TextDecorationNone)]
        None
    }
}
