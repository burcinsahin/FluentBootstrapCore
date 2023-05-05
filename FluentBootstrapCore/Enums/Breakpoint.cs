using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum Breakpoint
    {
        [Description()]
        Default,
        [Description("sm")]
        Small,
        [Description("md")]
        Medium,
        [Description("lg")]
        Large,
        [Description("xl")]
        XLarge,
        [Description("xxl")]
        XXLarge
    }
}
