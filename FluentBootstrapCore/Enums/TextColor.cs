using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum TextColor
    {
        [Description()]
        None,
        [Description(Css.TextPrimary)]
        Primary,
        [Description(Css.TextSecondary)]
        Secondary,
        [Description(Css.TextSuccess)]
        Success,
        [Description(Css.TextInfo)]
        Info,
        [Description(Css.TextWarning)]
        Warning,
        [Description(Css.TextDanger)]
        Danger,
        [Description(Css.TextLight)]
        Light,
        [Description(Css.TextDark)]
        Dark,
        [Description(Css.TextBody)]
        Body,
        [Description(Css.TextMuted)]
        Muted,
        [Description(Css.TextWhite)]
        White,
        [Description(Css.TextBlack50)]
        Black50,
        [Description(Css.TextWhite50)]
        White50,
    }
}