﻿using System;
using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    [Flags]
    public enum Border
    {
        [Description()]
        None = 0,
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
        All1 = 1 << 10 | All,
        [Description(Css.Border2)]
        All2 = 1 << 11 | All,
        [Description(Css.Border3)]
        All3 = 1 << 12 | All,
        [Description(Css.Border4)]
        All4 = 1 << 13 | All,
        [Description(Css.Border5)]
        All5 = 1 << 14 | All
    }
}