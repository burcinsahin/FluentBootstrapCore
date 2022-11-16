using FBootstrapCoreMvc;
using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum TextAlignment
    {
        [Description()]
        Default,
        [Description(Css.TextStart)]
        Left,
        [Description(Css.TextCenter)]
        Center,
        [Description(Css.TextEnd)]
        Right,
        [Description(Css.TextNowrap)]
        Nowrap
    }
}
