using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum Ratio
    {
        [Description(Css.Ratio1X1)]
        _1x1,
        [Description(Css.Ratio4X3)]
        _4x3,
        [Description(Css.Ratio16X9)]
        _16x9,
        [Description(Css.Ratio21X9)]
        _21x9,
    }
}