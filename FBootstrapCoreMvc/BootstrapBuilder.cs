using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FBootstrapCoreMvc
{
    public class BootstrapBuilder<TComponent, TModel> : BootstrapBuilder<TComponent>
        where TComponent : HtmlComponent
    {
        protected new readonly IHtmlHelper<TModel> _htmlHelper;

        internal new IHtmlHelper<TModel> HtmlHelper => _htmlHelper;

        public BootstrapBuilder(IHtmlHelper<TModel> htmlHelper, TComponent component)
            : base(htmlHelper, component)
        {
            _htmlHelper = htmlHelper;
        }
    }

    public class BootstrapBuilder<TComponent> : IDisposable
        where TComponent : HtmlComponent
    {
        protected readonly IHtmlHelper _htmlHelper;
        protected readonly TComponent _component;

        internal IHtmlHelper HtmlHelper => _htmlHelper;

        public BootstrapBuilder(IHtmlHelper htmlHelper, TComponent component)
        {
            _htmlHelper = htmlHelper;
            _component = component;
            _htmlHelper.ViewContext.Writer.Write(_component.Begin());
            _htmlHelper.ViewContext.Writer.Write(_component.Body());
        }

        public void Dispose()
        {
            _htmlHelper.ViewContext.Writer.Write(_component.End());
        }
    }
}
