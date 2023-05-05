using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum DisplayPrint
    {
        [Description(Css.DPrintNone)]
        PrintNone,
        [Description(Css.DPrintInline)]
        PrintInline,
        [Description(Css.DPrintInlineBlock)]
        PrintInlineBlock,
        [Description(Css.DPrintBlock)]
        PrintBlock,
        [Description(Css.DPrintGrid)]
        PrintGrid,
        [Description(Css.DPrintTable)]
        PrintTable,
        [Description(Css.DPrintTableRow)]
        PrintTableRow,
        [Description(Css.DPrintTableCell)]
        PrintTableCell,
        [Description(Css.DPrintFlex)]
        PrintFlex,
        [Description(Css.DPrintInlineFlex)]
        PrintInlineFlex
    }
}