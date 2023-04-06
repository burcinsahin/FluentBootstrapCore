using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum AlignContent
    {
        [Description("align-content{0}-start")]
        Start,
        [Description("align-content{0}-center")]
        Center,
        [Description("align-content{0}-end")]
        End,
        [Description("align-content{0}-around")]
        Around,
        [Description("align-content{0}-between")]
        Between,
        [Description("align-content{0}-stretch")]
        Stretch
    }
}
