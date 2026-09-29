using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public class BootstrapContent<TComponent>(IHtmlHelper htmlHelper, TComponent component) : IHtmlContent
        where TComponent : SingleComponent
    {
        public TComponent Component { get; } = component;
        internal IHtmlHelper HtmlHelper => htmlHelper;

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            var html = Component.ToHtml();
            writer.Write(html);
        }

        public ComponentBuilder<TComponent> Begin()
        {
            return new ComponentBuilder<TComponent>(HtmlHelper, Component);
        }
    }
}
