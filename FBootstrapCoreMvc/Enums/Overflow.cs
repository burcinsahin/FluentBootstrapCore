using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum Overflow
    {
        [Description(Css.OverflowAuto)]
        Auto,
        [Description(Css.OverflowHidden)]
        Hidden,
        [Description(Css.OverflowScroll)]
        Scroll,
        [Description(Css.OverflowVisible)]
        Visible,
    }
}
