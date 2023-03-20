using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum Display
    {
        [Description("d{0}-none")]
        None,
        [Description("d{0}-inline")]
        Inline,
        [Description("d{0}-inline-block")]
        InlineBlock,
        [Description("d{0}-block")]
        Block,
        [Description("d{0}-grid")]
        Grid,
        [Description("d{0}-table")]
        Table,
        [Description("d{0}-table-cell")]
        TableCell,
        [Description("d{0}-table-row")]
        TableRow,
        [Description("d{0}-flex")]
        Flex,
        [Description("d{0}-inline-flex")]
        InlineFlex,
    }
}