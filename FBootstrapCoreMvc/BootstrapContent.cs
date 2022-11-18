using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Text.Encodings.Web;

namespace FBootstrapCoreMvc
{
    public class BootstrapContent<TComponent> : IHtmlContent
        where TComponent : HtmlComponent
    {
        private readonly TComponent _component;
        private readonly IHtmlHelper _htmlHelper;

        internal TComponent Component => _component;

        public BootstrapContent(IHtmlHelper htmlHelper, TComponent component)
        {
            _htmlHelper = htmlHelper;
            _component = component;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var html = _component.ToHtml();
            writer.Write(html);
        }

        public BootstrapBuilder<TComponent> Begin()
        {
            return new BootstrapBuilder<TComponent>(_htmlHelper, _component);
        }
    }
}
