using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FBootstrapCoreMvc
{
    public class HtmlBuilder<TComponent> : IDisposable
        where TComponent : Component<TComponent>
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly TComponent _component;

        internal IHtmlHelper HtmlHelper => _htmlHelper;

        public HtmlBuilder(IHtmlHelper htmlHelper, TComponent component)
        {
            _component = component;
            _htmlHelper = htmlHelper;
            _htmlHelper.ViewContext.Writer.Write(_component.RenderStartTag());
            _htmlHelper.ViewContext.Writer.Write(_component.RenderBody());
        }

        public void Dispose()
        {
            _htmlHelper.ViewContext.Writer.Write(_component.RenderEndTag());
        }
    }
}
