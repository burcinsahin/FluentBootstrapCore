using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum FormControlSize
    {
        [Description()]
        Default,
        [Description(Css.FormControlLg)]
        Lg,
        [Description(Css.FormControlSm)]
        Sm
    }
}