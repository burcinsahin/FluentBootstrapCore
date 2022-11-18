using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FBootstrapCoreMvc
{
    public class BootstrapBuilder<TComponent> : IDisposable
        where TComponent : HtmlComponent
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly TComponent _component;

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
