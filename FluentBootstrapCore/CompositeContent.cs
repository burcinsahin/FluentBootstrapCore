using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace FluentBootstrapCore
{
    public class CompositeContent<TComponent>(IHtmlHelper htmlHelper, TComponent component) : IHtmlContent
    where TComponent : IHtmlComponent
    {
        internal TComponent Component => component;
        internal IHtmlHelper HtmlHelper => htmlHelper;

        /// <summary>
        /// Parent components (top to bottom) at creation time. Razor defers WriteTo until the
        /// view buffer is flushed, after enclosing using blocks have popped the component stack,
        /// so the context is captured here and restored in WriteTo.
        /// </summary>
        private readonly IReadOnlyList<IHtmlComponent> _parents =
            ComponentStackManager.SnapshotFor(htmlHelper);

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            ComponentStackManager.Use(htmlHelper);
            var stack = ComponentStackManager.ComponentStack;
            for (var i = _parents.Count - 1; i >= 0; i--)
                stack?.Push(_parents[i]);
            try
            {
                var html = component.ToHtml();
                writer.Write(html);
            }
            finally
            {
                for (var i = 0; i < _parents.Count; i++)
                    stack?.Pop();
            }
        }
    }
}
