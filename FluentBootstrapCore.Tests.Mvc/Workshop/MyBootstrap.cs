using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluentBootstrapCore.Tests.Mvc.Workshop
{
    public class MyBootstrap<TModel>
    {
        IHtmlHelper _htmlHelper;
        public MyBootstrap(IHtmlHelper<TModel> helper)
        {
            _htmlHelper = helper;
        }

        public MyDiv Div(string? text = null)
        {
            return new MyDiv(text);
        }

        public MyBuilder<TComponent> Begin<TComponent>(TComponent component)
            where TComponent : TagBuilder
        {
            return new MyBuilder<TComponent>(_htmlHelper, component);
        }
    }
}