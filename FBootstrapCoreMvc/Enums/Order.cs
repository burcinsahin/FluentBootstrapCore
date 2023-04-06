using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum Order
    {
        [Description(Css.Order0)]
        O0 = 0,
        [Description(Css.Order1)]
        O1 = 1,
        [Description(Css.Order2)]
        O2 = 2,
        [Description(Css.Order3)]
        O3 = 3,
        [Description(Css.Order4)]
        O4 = 4,
        [Description(Css.Order5)]
        O5 = 5,
        [Description(Css.OrderFirst)]
        First = -1,
        [Description(Css.OrderLast)]
        Last = 6
    }
}
