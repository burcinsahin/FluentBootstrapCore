using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Text.Encodings.Web;

namespace FluentBootstrapCore
{
    public class CompositeContent<TComponent>(IHtmlHelper htmlHelper, TComponent component) : IHtmlContent
    where TComponent : IHtmlComponent
    {
        internal TComponent Component => component;
        internal IHtmlHelper HtmlHelper => htmlHelper;

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var html = component.ToHtml();
            writer.Write(html);
        }
    }
}
