using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum LengthUnit
    {
        /// <summary>
        /// px
        /// </summary>
        [Description("cm")]
        Centimeter,
        /// <summary>
        /// mm
        /// </summary>
        [Description("mm")]
        Millimeter,
        /// <summary>
        /// in
        /// </summary>
        [Description("in")]
        Inch,
        /// <summary>
        /// px
        /// </summary>
        [Description("px")]
        Pixel,
        /// <summary>
        /// pt
        /// </summary>
        [Description("pt")]
        Point,
        /// <summary>
        /// pc
        /// </summary>
        [Description("pc")]
        Picas,
        /// <summary>
        /// em
        /// </summary>
        [Description("em")]
        Element,
        /// <summary>
        /// rem
        /// </summary>
        [Description("rem")]
        RootElement
    }
}
