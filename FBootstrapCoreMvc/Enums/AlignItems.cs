using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum AlignItems
    {
        [Description("align-items{0}-start")]
        Start,
        [Description("align-items{0}-center")]
        Center,
        [Description("align-items{0}-end")]
        End,
        [Description("align-items{0}-baseline")]
        Baseline,
        [Description("align-items{0}-stretch")]
        Stretch
    }
}
