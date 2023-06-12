using System;
using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    [Flags]
    public enum TableStyle
    {
        [Description(Css.TableStriped)]
        Striped = 1,
        [Description(Css.TableStripedColumns)]
        StripedColumns = 1 << 1,
        [Description(Css.TableBordered)]
        Bordered = 1 << 2,
        [Description(Css.TableBorderless)]
        Borderless = 1 << 3
    }
}
