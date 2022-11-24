using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FBootstrapCoreMvc
{
    [Obsolete("Use BootstrapBuilder instead.")]
    public class MvcBuilder<TComponent, TModel> : IDisposable
        where TComponent : MvcComponent<TComponent, TModel>
    {
        private readonly IHtmlHelper<TModel> _htmlHelper;
        private readonly TComponent _component;

        internal IHtmlHelper<TModel> HtmlHelper => _htmlHelper;

        public MvcBuilder(IHtmlHelper<TModel> htmlHelper, TComponent component)
        {
            _component = component;
            _htmlHelper = htmlHelper;
            _htmlHelper.ViewContext.Writer.Write(component.RenderStartTag());
            _htmlHelper.ViewContext.Writer.Write(_component.RenderBody());
        }

        public void Dispose()
        {
            _htmlHelper.ViewContext.Writer.Write(_component.RenderEndTag());
        }
    }
}
