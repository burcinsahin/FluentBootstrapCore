using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum ButtonGroupSize
    {
        [Description()]
        Default,
        [Description(Css.BtnGroupLg)]
        Lg,
        [Description(Css.BtnGroupSm)]
        Sm
    }
}
