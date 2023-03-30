using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum BorderRadius
    {
        [Description()]
        None,
        [Description(Css.Rounded)]
        Rounded,
        [Description(Css.Rounded0)]
        Rounded0,
        [Description(Css.Rounded1)]
        Rounded1,
        [Description(Css.Rounded2)]
        Rounded2,
        [Description(Css.Rounded3)]
        Rounded3,
        [Description(Css.Rounded4)]
        Rounded4,
        [Description(Css.Rounded5)]
        Rounded5,
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