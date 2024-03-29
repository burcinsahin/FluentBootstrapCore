﻿using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum Padding
    {
        [Description("p")]
        All,
        [Description("ps")]
        Start,
        [Description("pe")]
        End,
        [Description("pt")]
        Top,
        [Description("pb")]
        Bottom,
        [Description("px")]
        Horizontal,
        [Description("py")]
        Vertical,
    }
}
