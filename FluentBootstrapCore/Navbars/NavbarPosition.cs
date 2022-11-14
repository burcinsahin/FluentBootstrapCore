using System.ComponentModel;

namespace FluentBootstrapCore
{
    public enum NavbarPosition
    {
        [Description()]
        Default,
        [Description(/*Css.NavbarFixedTop*/)]
        FixedTop,
        [Description(/*Css.NavbarFixedBottom*/)]
        FixedBottm,
        [Description(/*Css.NavbarStaticTop*/)]
        StaticTop
    }
}
