using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public new BootstrapBuilder<TComponent, TModel> Begin()
        {
            return new BootstrapBuilder<TComponent, TModel>(_htmlHelper, _component);
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
            var html = _component.ToHtml();
            writer.Write(html);
        }

        public BootstrapBuilder<TComponent> Begin()
        {
            return new BootstrapBuilder<TComponent>(_htmlHelper, _component);
        }
    }
}
