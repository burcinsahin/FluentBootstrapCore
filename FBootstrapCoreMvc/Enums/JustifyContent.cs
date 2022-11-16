using FBootstrapCoreMvc;
using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum JustifyContent
    {
        [Description(Css.JustifyContentAround)]
        Around,
        [Description(Css.JustifyContentBetween)]
        Between,
        [Description(Css.JustifyContentCenter)]
        Center,
        [Description(Css.JustifyContentEnd)]
        End,
        [Description(Css.JustifyContentEvenly)]
        Evenly,
        [Description(Css.JustifyContentStart)]
        Start
    }
}