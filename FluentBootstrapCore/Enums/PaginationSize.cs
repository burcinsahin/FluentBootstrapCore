using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum PaginationSize
    {
        [Description()]
        Default,
        [Description(Css.PaginationSm)]
        Small,
        [Description(Css.PaginationLg)]
        Large
    }
}