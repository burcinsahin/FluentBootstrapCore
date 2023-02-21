using System.ComponentModel;

namespace FBootstrapCoreMvc.Enums
{
    public enum FormSelectSize
    {
        [Description()]
        Default,
        [Description(Css.FormSelectLg)]
        Lg,
        [Description(Css.FormSelectSm)]
        Sm
    }
}