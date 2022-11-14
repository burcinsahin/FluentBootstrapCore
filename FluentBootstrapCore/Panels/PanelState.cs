using System.ComponentModel;

namespace FluentBootstrapCore
{
    public enum PanelState
    {
        [Description(/*Css.PanelDefault*/)]
        Default,
        [Description(/*Css.PanelPrimary*/)]
        Primary,
        [Description(/*Css.PanelSuccess*/)]
        Success,
        [Description()]
        Info,
        [Description()]
        Warning,
        [Description()]
        Danger
    }
}
