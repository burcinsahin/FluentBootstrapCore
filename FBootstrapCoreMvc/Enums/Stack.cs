using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum Stack
    {
        [Description(Css.Vstack)]
        Vertical,
        [Description(Css.Hstack)]
        Horizontal
    }
}