using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum VerticalAlign
    {
        [Description(Css.AlignBaseline)]
        Baseline,
        [Description(Css.AlignTop)]
        Top,
        [Description(Css.AlignMiddle)]
        Middle,
        [Description(Css.AlignBottom)]
        Bottom,
        [Description(Css.AlignTextBottom)]
        TextBottom,
        [Description(Css.AlignTextTop)]
        TextTop
    }
}