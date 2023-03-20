using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum Border
    {
        [Description(Css.Border)]
        All,
        [Description(Css.Border0)]
        NoAll,
        [Description(Css.Border1)]
        All1,
        [Description(Css.Border2)]
        All2,
        [Description(Css.Border3)]
        All3,
        [Description(Css.Border4)]
        All4,
        [Description(Css.Border5)]
        All5,
        [Description(Css.BorderTop)]
        Top,
        [Description(Css.BorderStart)]
        Start,
        [Description(Css.BorderEnd)]
        End,
        [Description(Css.BorderBottom)]
        Bottom,
        [Description(Css.BorderTop0)]
        NoTop,
        [Description(Css.BorderStart0)]
        NoStart,
        [Description(Css.BorderEnd0)]
        NoEnd,
        [Description(Css.BorderBottom0)]
        NoBottom
    }
}