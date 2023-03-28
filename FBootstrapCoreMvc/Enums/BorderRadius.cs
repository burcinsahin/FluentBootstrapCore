using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum BorderRadius
    {
        [Description()]
        None,
        [Description(Css.Rounded)]
        Rounded,
        [Description(Css.RoundedTop)]
        RoundedTop,
        [Description(Css.RoundedEnd)]
        RoundedEnd,
        [Description(Css.RoundedBottom)]
        RoundedBottom,
        [Description(Css.RoundedStart)]
        RoundedStart,
        [Description(Css.RoundedCircle)]
        RoundedCircle,
        [Description(Css.RoundedPill)]
        RoundedPill
    }
}