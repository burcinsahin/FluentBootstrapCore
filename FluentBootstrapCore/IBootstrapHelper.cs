using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluentBootstrapCore
{
    public interface IBootstrapHelper
    {
        IHtmlHelper HtmlHelper { get; }
    }
}