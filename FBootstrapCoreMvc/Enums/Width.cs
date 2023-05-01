using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    public enum Width
    {
        /// <summary>
        /// Auto
        /// </summary>
        [Description(Css.WAuto)]
        Auto,
        /// <summary>
        /// %25
        /// </summary>
        [Description(Css.W25)]
        _25,
        /// <summary>
        /// %50
        /// </summary>
        [Description(Css.W50)]
        _50,
        /// <summary>
        /// %75
        /// </summary>
        [Description(Css.W75)]
        _75,
        /// <summary>
        /// %100
        /// </summary>
        [Description(Css.W100)]
        _100,
        /// <summary>
        /// Max. width %100
        /// </summary>
        [Description(Css.Mw100)]
        Max100,
        /// <summary>
        /// Minimum relative to viewport
        /// </summary>
        [Description(Css.MinVw100)]
        MinViewport100,
        /// <summary>
        /// Relative to viewport
        /// </summary>
        [Description(Css.Vw100)]
        Viewport100,
    }
}
