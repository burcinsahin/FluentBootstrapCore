using FBootstrapCoreMvc;
using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum ButtonSize
    {
        [Description()]
        Default,
        [Description(Css.BtnLg)]
        Lg,
        [Description(Css.BtnSm)]
        Sm
    }
}
