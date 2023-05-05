using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum Height
    {
        /// <summary>
        /// Auto
        /// </summary>
        [Description(Css.HAuto)]
        Auto,
        /// <summary>
        /// %25
        /// </summary>
        [Description(Css.H25)]
        _25,
        /// <summary>
        /// %50
        /// </summary>
        [Description(Css.H50)]
        _50,
        /// <summary>
        /// %75
        /// </summary>
        [Description(Css.H75)]
        _75,
        /// <summary>
        /// %100
        /// </summary>
        [Description(Css.H100)]
        _100,
        /// <summary>
        /// Max. height %100
        /// </summary>
        [Description(Css.Mh100)]
        Max100,
        /// <summary>
        /// Minimum relative to viewport
        /// </summary>
        [Description(Css.MinVh100)]
        MinViewport100,
        /// <summary>
        /// Relative to viewport
        /// </summary>
        [Description(Css.Vh100)]
        Viewport100,
    }
}
