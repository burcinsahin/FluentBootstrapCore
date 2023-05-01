using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum UserSelect
    {
        [Description(Css.UserSelectNone)]
        None,
        [Description(Css.UserSelectAll)]
        All,
        [Description(Css.UserSelectAuto)]
        Auto
    }
}