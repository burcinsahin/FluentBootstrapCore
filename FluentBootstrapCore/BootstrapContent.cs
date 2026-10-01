using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace FluentBootstrapCore
{
    public class BootstrapContent<TComponent, TModel>(IHtmlHelper<TModel> htmlHelper, TComponent component) : BootstrapContent<TComponent>(htmlHelper, component)
        where TComponent : SingleComponent
    {
        internal new IHtmlHelper<TModel> HtmlHelper => htmlHelper;

        public new ComponentBuilder<TComponent, TModel> Begin()
        {
            return new ComponentBuilder<TComponent, TModel>(htmlHelper, Component);
        }
    }

    /// <summary>
    /// BootstrapContent wraps a component for use in Razor views.
    /// It implements IHtmlContent to prevent HTML encoding of the rendered output.
    /// The WriteTo method is called during view rendering.
    /// </summary>
    public class BootstrapContent<TComponent>(IHtmlHelper htmlHelper, TComponent component) : IHtmlContent
        where TComponent : SingleComponent
    {
        public TComponent Component { get; } = component;
        internal IHtmlHelper HtmlHelper => htmlHelper;

        /// <summary>
        /// Parent components (top to bottom) at creation time. Razor defers WriteTo until the
        /// view buffer is flushed, by which time enclosing using blocks have been disposed and
        /// popped from the component stack, so the context is captured here and restored in WriteTo.
        /// </summary>
        private readonly IReadOnlyList<IHtmlComponent> _parents =
            ComponentStackManager.SnapshotFor(htmlHelper);

        /// <summary>
        /// Render component to HTML without encoding.
        /// This is called by Razor during normal rendering flow.
        /// </summary>
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            // Write the component's HTML directly to the output without encoding
            ComponentStackManager.Use(htmlHelper);
            var stack = ComponentStackManager.ComponentStack;
            for (var i = _parents.Count - 1; i >= 0; i--)
                stack?.Push(_parents[i]);
            try
            {
                var html = Component.ToHtml();
                writer.Write(html);
            }
            finally
            {
                for (var i = 0; i < _parents.Count; i++)
                    stack?.Pop();
            }
        }

        /// <summary>
        /// Begin a using block for this component.
        /// Example: @using (Html.Bootstrap().Form().Begin()) { ... }
        /// </summary>
        public ComponentBuilder<TComponent> Begin()
        {
            return new ComponentBuilder<TComponent>(HtmlHelper, Component);
        }
    }
}
