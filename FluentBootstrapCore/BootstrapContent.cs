using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.IO;
using System.Text.Encodings.Web;

namespace FluentBootstrapCore
{
    public class BootstrapContent<TComponent, TModel> : BootstrapContent<TComponent>
        where TComponent : SingleComponent
    {
        private readonly TComponent _component;
        private readonly IHtmlHelper<TModel> _htmlHelper;

        internal new IHtmlHelper<TModel> HtmlHelper => _htmlHelper;

        public BootstrapContent(IHtmlHelper<TModel> htmlHelper, TComponent component)
            : base(htmlHelper, component)
        {
            _htmlHelper = htmlHelper;
            _component = component;
        }

        public new ComponentBuilder<TComponent, TModel> Begin()
        {
            return new ComponentBuilder<TComponent, TModel>(_htmlHelper, _component);
        }
    }

    public class BootstrapContent<TComponent> : IHtmlContent
        where TComponent : SingleComponent
    {
        private readonly TComponent _component;
        private readonly IHtmlHelper _htmlHelper;

        internal TComponent Component => _component;
        internal IHtmlHelper HtmlHelper => _htmlHelper;

        public BootstrapContent(IHtmlHelper htmlHelper, TComponent component)
        {
            _htmlHelper = htmlHelper;
            _component = component;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            Debug.WriteLine($"BootstrapContent.WriteTo invoked.");
            var html = _component.ToHtml();
            writer.Write(html);
        }

        public ComponentBuilder<TComponent> Begin()
        {
            Debug.WriteLine($"BootstrapContent.Begin invoked.");
            return new ComponentBuilder<TComponent>(_htmlHelper, _component);
        }
    }
}
