using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Text.Encodings.Web;

namespace FBootstrapCoreMvc
{
    public class CompositeContent<TComponent> : IHtmlContent
    where TComponent : IHtmlComponent
    {
        private readonly TComponent _component;
        private readonly IHtmlHelper _htmlHelper;

        internal TComponent Component => _component;
        internal IHtmlHelper HtmlHelper => _htmlHelper;

        public CompositeContent(IHtmlHelper htmlHelper, TComponent component)
        {
            _htmlHelper = htmlHelper;
            _component = component;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var html = _component.ToHtml();
            writer.Write(html);
        }
    }
}
