using FluentBootstrapCore.Components;

namespace FluentBootstrapCore.Extensions
{
    public static class CloseButtonExtensions
    {
        /// <summary>
        /// Switches to the white variant (<c>.btn-close-white</c>), for use on dark backgrounds.
        /// </summary>
        public static BootstrapContent<CloseButton> White(this BootstrapContent<CloseButton> bootstrapContent, bool value = true)
        {
            bootstrapContent.Component.White = value;
            return bootstrapContent;
        }

        /// <summary>
        /// Sets the <c>aria-label</c> text for screen readers (default: "Close").
        /// </summary>
        public static BootstrapContent<CloseButton> AriaLabel(this BootstrapContent<CloseButton> bootstrapContent, string label)
        {
            bootstrapContent.Component.AriaLabel = label;
            return bootstrapContent;
        }

        /// <summary>
        /// Makes the button dismiss the given component via <c>data-bs-dismiss</c> (e.g. "alert", "modal", "toast", "offcanvas").
        /// </summary>
        public static BootstrapContent<CloseButton> Dismiss(this BootstrapContent<CloseButton> bootstrapContent, string target)
        {
            bootstrapContent.Component.MergeAttribute("data-bs-dismiss", target);
            return bootstrapContent;
        }
    }
}
