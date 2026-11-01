namespace FluentBootstrapCore.Interfaces
{
    /// <summary>
    /// Component that renders validation feedback (<c>valid-feedback</c> / <c>invalid-feedback</c>) next to its input.
    /// </summary>
    public interface ICanHaveFeedback
    {
        string? ValidFeedback { get; set; }
        string? InvalidFeedback { get; set; }

        /// <summary>
        /// Renders the feedback as a tooltip (<c>valid-tooltip</c> / <c>invalid-tooltip</c>) instead of a block.
        /// </summary>
        bool FeedbackTooltip { get; set; }
    }
}
