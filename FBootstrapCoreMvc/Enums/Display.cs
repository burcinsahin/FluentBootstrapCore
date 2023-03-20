using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum Display
    {
        [Description(Css.DNone)]
        None,
        [Description(Css.DInline)]
        Inline,
        [Description(Css.DInlineBlock)]
        InlineBlock,
        [Description(Css.DBlock)]
        Block,
        [Description(Css.DGrid)]
        Grid,
        [Description(Css.DTable)]
        Table,
        [Description(Css.DTableCell)]
        TableCell,
        [Description(Css.DTableRow)]
        TableRow,
        [Description(Css.DFlex)]
        Flex,
        [Description(Css.DInlineFlex)]
        InlineFlex,
    }
}