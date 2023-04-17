using System;
using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    [Flags]
    public enum Absolute
    {
        [Description(Css.Top0)]
        Top0 = 1,
        [Description(Css.Top50)]
        Top50 = 1 << 1,
        [Description(Css.Top100)]
        Top100 = 1 << 2,
        [Description(Css.Start0)]
        Start0 = 1 << 3,
        [Description(Css.Start50)]
        Start50 = 1 << 4,
        [Description(Css.Start100)]
        Start100 = 1 << 5,
        [Description(Css.Bottom0)]
        Bottom0 = 1 << 6,
        [Description(Css.Bottom50)]
        Bottom50 = 1 << 7,
        [Description(Css.Bottom100)]
        Bottom100 = 1 << 8,
        [Description(Css.End0)]
        End0 = 1 << 9,
        [Description(Css.End50)]
        End50 = 1 << 10,
        [Description(Css.End100)]
        End100 = 1 << 11,
        TopEnd = Top0 | End0,
        BottomEnd = Bottom0 | End0,
        TopStart = Top0 | Start0,
        BottomStart = Bottom0 | Start0
    }
}