using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Generic close button (<c>.btn-close</c>) for dismissing content like modals and alerts.
    /// </summary>
    public class CloseButton : BootstrapComponent, ICanBeDisabled
    {
        public bool Disabled { get; set; }

        /// <summary>
        /// Uses the <c>.btn-close-white</c> variant (for dark backgrounds).
        /// </summary>
        public bool White { get; set; }

        /// <summary>
        /// Text for screen readers. Defaults to "Close".
        /// </summary>
        public string AriaLabel { get; set; } = "Close";

        public CloseButton()
            : base("button", Css.BtnClose)
        {
            MergeAttribute("type", "button");
        }

        protected override void PreBuild()
        {
            if (White)
                AddCss(Css.BtnCloseWhite);

            if (Disabled)
                MergeAttribute("disabled");

            MergeAttribute("aria-label", AriaLabel);

            base.PreBuild();
        }
    }
}
