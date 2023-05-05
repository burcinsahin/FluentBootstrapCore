using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum LinkTarget
    {
        [Description("_blank")]
        Blank,
        [Description("_self")]
        Self,
        [Description("_parent")]
        Parent,
        [Description("_top")]
        Top
    }
}