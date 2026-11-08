using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    /// <summary>
    /// Value of the <c>data-bs-ride</c> attribute of a carousel.
    /// </summary>
    public enum CarouselRide
    {
        /// <summary>
        /// Autoplays the carousel on load (<c>data-bs-ride="carousel"</c>).
        /// </summary>
        [Description("carousel")]
        OnLoad,
        /// <summary>
        /// Autoplays the carousel after the user manually cycles the first item (<c>data-bs-ride="true"</c>).
        /// </summary>
        [Description("true")]
        AfterInteraction
    }
}
