using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

namespace FBootstrapCoreMvc
{
    public static class HtmlHelperExtensions
    {
        public static Bootstrap<TModel> Bootstrap<TModel>(this IHtmlHelper<TModel> htmlHelper)
        {
            return new Bootstrap<TModel>(htmlHelper);
        }

        public static string ToHtmlString(this IHtmlContent htmlContent)
        {
            using (var writer = new StringWriter())
            {
                htmlContent.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }

        public static ModelExpressionProvider GetModelExpressionProvider(this IHtmlHelper htmlHelper)
        {
            var modelExpressionProvider = htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(ModelExpressionProvider)) as ModelExpressionProvider;
            if (modelExpressionProvider == null)
                throw new InvalidOperationException($"{nameof(ModelExpressionProvider)} must be registered!");
            return modelExpressionProvider;
        }

        public static IUrlHelper GetUrlHelper(this IHtmlHelper htmlHelper)
        {
            var urlHelperFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            if (urlHelperFactory == null)
                throw new InvalidOperationException($"{nameof(IUrlHelperFactory)} must be registered!");
            var urlHelper = urlHelperFactory.GetUrlHelper(htmlHelper.ViewContext);
            if (urlHelper == null)
                throw new InvalidOperationException($"{nameof(IUrlHelper)} must be provided!");
            return urlHelper;
        }
    }
}
