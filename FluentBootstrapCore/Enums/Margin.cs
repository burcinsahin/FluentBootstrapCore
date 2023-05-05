using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum Margin
    {
        [Description("m")]
        All,
        [Description("ms")]
        Start,
        [Description("me")]
        End,
        [Description("mt")]
        Top,
        [Description("mb")]
        Bottom,
        [Description("mx")]
        Horizontal,
        [Description("my")]
        Vertical
    }
}
