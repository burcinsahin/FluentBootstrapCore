using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum FontWeight
    {
        [Description(Css.FwBold)]
        Bold,
        [Description(Css.FwBolder)]
        Bolder,
        [Description(Css.FwSemibold)]
        SemiBold,
        [Description(Css.FwNormal)]
        Normal,
        [Description(Css.FwLight)]
        Light,
        [Description(Css.FwLighter)]
        Lighter
    }
}