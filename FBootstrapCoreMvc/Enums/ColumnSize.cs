using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum ColumnSize
    {
        [Description("")]
        None,
        [Description(Css.ColSm)]
        Small,
        [Description(Css.ColMd)]
        Medium,
        [Description(Css.ColLg)]
        Large,
        [Description(Css.ColXl)]
        XLarge,
        [Description(Css.ColXxl)]
        XXLarge
    }
}