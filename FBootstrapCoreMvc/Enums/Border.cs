using System;
using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    [Flags]
    public enum Border
    {
        [Description(Css.Border0)]
        NoAll = 1,
        [Description(Css.Border)]
        All = 1 << 1,
        [Description(Css.BorderTop)]
        Top = 1 << 2,
        [Description(Css.BorderStart)]
        Start = 1 << 3,
        [Description(Css.BorderEnd)]
        End = 1 << 4,
        [Description(Css.BorderBottom)]
        Bottom = 1 << 5,
        [Description(Css.BorderTop0)]
        NoTop = 1 << 6,
        [Description(Css.BorderStart0)]
        NoStart = 1 << 7,
        [Description(Css.BorderEnd0)]
        NoEnd = 1 << 8,
        [Description(Css.BorderBottom0)]
        NoBottom = 1 << 9,
        [Description(Css.Border1)]
        All1 = 3 << 1,
        [Description(Css.Border2)]
        All2 = 3 << 2,
        [Description(Css.Border3)]
        All3 = 3 << 3,
        [Description(Css.Border4)]
        All4 = 3 << 4,
        [Description(Css.Border5)]
        All5 = 3 << 5
    }
}