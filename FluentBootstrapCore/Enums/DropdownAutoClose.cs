using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    /// <summary>
    /// Value of the <c>data-bs-auto-close</c> attribute of a dropdown toggle.
    /// </summary>
    public enum DropdownAutoClose
    {
        /// <summary>
        /// Closed by clicking inside or outside the menu (<c>true</c>).
        /// </summary>
        [Description("true")]
        Default,
        /// <summary>
        /// Closed (only) by clicking inside the menu (<c>inside</c>).
        /// </summary>
        [Description("inside")]
        Inside,
        /// <summary>
        /// Closed (only) by clicking outside the menu (<c>outside</c>).
        /// </summary>
        [Description("outside")]
        Outside,
        /// <summary>
        /// Closed only by clicking the toggle or calling hide/toggle (<c>false</c>).
        /// </summary>
        [Description("false")]
        Manual
    }
}
