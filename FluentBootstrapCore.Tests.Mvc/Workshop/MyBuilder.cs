using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluentBootstrapCore.Tests.Mvc.Workshop
{
    public class MyBuilder<TComponent> : IDisposable 
        where TComponent : TagBuilder
    {
        IHtmlHelper _htmlHelper;
        TComponent _component;

        public MyBuilder(IHtmlHelper htmlHelper, TComponent component)
        {
            _component = component;
            _htmlHelper = htmlHelper;
            _htmlHelper.ViewContext.Writer.Write(component.RenderStartTag());
            //component.WriteTo()
        }

        public void Dispose()
        {
            _htmlHelper.ViewContext.Writer.Write(_component.RenderEndTag());
        }
    }
}
