using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum Visibility
    {
        [Description(Css.Visible)]
        Visible,
        [Description(Css.Invisible)]
        Invisible
    }
}