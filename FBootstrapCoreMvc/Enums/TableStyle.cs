using System;
using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    [Flags]
    public enum TableStyle
    {
        [Description(Css.TableStriped)]
        Striped = 1,
        [Description(Css.TableBordered)]
        Bordered = 1 << 1,
        [Description(Css.TableHover)]
        Hover = 1 << 2
    }
}
