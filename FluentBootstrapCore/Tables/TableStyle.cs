using System;
using System.ComponentModel;

namespace FluentBootstrapCore
{
    [Flags]
    public enum TableStyle
    {
        [Description(Css.TableStriped)]
        Striped = 1,
        [Description(Css.TableBordered)]
        Bordered = 1 << 1,
        [Description(Css.TableHover)]
        Hover = 1 << 2,
        //[Description(Css.TableCondensed)]
        //Condensed = 1 << 3
    }
}
