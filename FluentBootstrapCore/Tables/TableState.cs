using System.ComponentModel;

namespace FluentBootstrapCore
{
    public enum TableState
    {
        [Description()]
        Default,
        [Description(Css.Active)]
        Active,
        //[Description(Css.Success)]
        //Success,
        //[Description(Css.Warning)]
        //Warning,
        //[Description(Css.Danger)]
        //Danger,
        //[Description(Css.Info)]
        //Info
    }
}
