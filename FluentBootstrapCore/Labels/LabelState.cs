using System.ComponentModel;

namespace FluentBootstrapCore
{

    public enum LabelState
    {
        [Description(Css.TextInfo)]
        Default,
        [Description(Css.TextPrimary)]
        Primary,
        [Description(Css.TextSuccess)]
        Success,
        [Description(Css.TextInfo)]
        Info,
        [Description(Css.TextWarning)]
        Warning,
        [Description(Css.TextDanger)]
        Danger
    }
}
