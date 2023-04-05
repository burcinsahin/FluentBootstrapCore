using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum FlexDirection
    {
        [Description("flex{0}-row")]
        Row,
        [Description("flex{0}-column")]
        Column,
        [Description("flex{0}-row-reverse")]
        RowReverse,
        [Description("flex{0}-column-reverse")]
        ColumnReverse,
        [Description("flex{0}-nowrap")]
        NoWrap,
        [Description("flex{0}-wrap")]
        Wrap,
        [Description("flex{0}-wrap-reverse")]
        WrapReverse
    }
}