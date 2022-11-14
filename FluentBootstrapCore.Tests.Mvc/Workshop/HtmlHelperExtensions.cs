using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluentBootstrapCore.Tests.Mvc.Workshop
{
    public static class HtmlHelperExtensions
    {
        public static MyBootstrap<TModel> MyBootstrap<TModel>(this IHtmlHelper<TModel> htmlHelper)
        {
            return new MyBootstrap<TModel>(htmlHelper);
        }
    }
}
