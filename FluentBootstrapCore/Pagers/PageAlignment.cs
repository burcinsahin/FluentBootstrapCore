using System.ComponentModel;

namespace FluentBootstrapCore
{
    public enum PageAlignment
    {
        [Description()]
        Default,
        [Description(/*Css.Previous*/)]
        Previous,
        [Description(/*Css.Next*/)]
        Next
    }
}
