using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum Translate
    {
        [Description(Css.TranslateMiddle)]
        Middle,
        [Description(Css.TranslateMiddleX)]
        MiddleX,
        [Description(Css.TranslateMiddleY)]
        MiddleY
    }
}