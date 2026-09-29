using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FluentBootstrapCore
{
    public class ComponentBuilder<TComponent, TModel>(IHtmlHelper<TModel> htmlHelper, TComponent component) : ComponentBuilder<TComponent>(htmlHelper, component)
        where TComponent : SingleComponent
    {
        protected new readonly IHtmlHelper<TModel> _htmlHelper = htmlHelper;

        internal new IHtmlHelper<TModel> HtmlHelper => _htmlHelper;
    }

    public class ComponentBuilder<TComponent> : IDisposable
        where TComponent : SingleComponent
    {
        protected readonly IHtmlHelper _htmlHelper;
        protected readonly TComponent _component;

        internal IHtmlHelper HtmlHelper => _htmlHelper;
        internal TComponent Component => _component;

        public ComponentBuilder(IHtmlHelper htmlHelper, TComponent component)
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
