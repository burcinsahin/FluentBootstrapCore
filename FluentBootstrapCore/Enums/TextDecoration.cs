using System.ComponentModel;

namespace FluentBootstrapCore.Enums
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
