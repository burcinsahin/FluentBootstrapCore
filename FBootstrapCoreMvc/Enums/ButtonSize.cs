﻿using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum ButtonSize
    {
        [Description()]
        Default,
        [Description(Css.BtnLg)]
        Large,
        [Description(Css.BtnSm)]
        Small
    }
}
