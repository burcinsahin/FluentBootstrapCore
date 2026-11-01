using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Builds the validation feedback elements of a form control.
    /// </summary>
    /// <remarks>
    /// Bootstrap shows feedback with sibling selectors (<c>.form-control:invalid ~ .invalid-feedback</c>), so the
    /// feedback has to be rendered inside the same element that contains the input, right after it.
    /// </remarks>
    internal static class ValidationFeedback
    {
        /// <summary>
        /// Applies the validation feedback to the wrapper element of a form control.
        /// </summary>
        /// <param name="source">Component holding the feedback texts.</param>
        /// <param name="wrapper">Element that contains the input (the feedback is added to it).</param>
        /// <param name="input">The input element the feedback belongs to.</param>
        /// <param name="invalid">Server side invalid state of the control.</param>
        /// <param name="valid">Server side valid state of the control.</param>
        public static void Apply(ICanHaveFeedback source, SingleComponent wrapper, SingleComponent input, bool invalid, bool valid)
        {
            if (source.ValidFeedback == null && source.InvalidFeedback == null)
                return;

            if (source.FeedbackTooltip)
                wrapper.AddCss(Css.PositionRelative);

            HtmlElement? validElement = null;
            HtmlElement? invalidElement = null;

            if (source.ValidFeedback != null)
            {
                validElement = Create(source.ValidFeedback, source.FeedbackTooltip ? Css.ValidTooltip : Css.ValidFeedback, input, "valid");
                wrapper.AddChild(validElement);
            }

            if (source.InvalidFeedback != null)
            {
                invalidElement = Create(source.InvalidFeedback, source.FeedbackTooltip ? Css.InvalidTooltip : Css.InvalidFeedback, input, "invalid");
                wrapper.AddChild(invalidElement);
            }

            // Only link the message that is currently shown by the server side state
            var describedBy = invalid ? invalidElement?.Id : valid ? validElement?.Id : null;
            if (describedBy != null)
                input.MergeAttribute("aria-describedby", describedBy);
        }

        private static HtmlElement Create(string text, string css, SingleComponent input, string suffix)
        {
            var element = new HtmlElement("div", css)
            {
                Content = text
            };
            if (input.Id != null)
                element.Id = $"{input.Id}_{suffix}";
            return element;
        }
    }
}
