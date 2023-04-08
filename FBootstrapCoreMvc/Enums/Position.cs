using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum Position
    {
        [Description(Css.PositionStatic)]
        Static,
        [Description(Css.PositionRelative)]
        Relative,
        [Description(Css.PositionAbsolute)]
        Absolute,
        [Description(Css.PositionFixed)]
        Fixed,
        [Description(Css.PositionSticky)]
        Sticky
    }
}