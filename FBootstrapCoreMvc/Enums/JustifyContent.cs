using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum JustifyContent
    {
        [Description("justify-content{0}-around")]
        Around,
        [Description("justify-content{0}-between")]
        Between,
        [Description("justify-content{0}-center")]
        Center,
        [Description("justify-content{0}-end")]
        End,
        [Description("justify-content{0}-evenly")]
        Evenly,
        [Description("justify-content{0}-start")]
        Start
    }
}