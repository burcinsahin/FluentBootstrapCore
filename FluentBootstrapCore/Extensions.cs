using Microsoft.AspNetCore.Html;
using System.IO;
using System.Text.Encodings.Web;

namespace FluentBootstrapCore
{
    public static class Extensions
    {
        public static string ToHtmlString(this IHtmlContent htmlContent)
        {
            using (var writer = new StringWriter())
            {
                htmlContent.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}
