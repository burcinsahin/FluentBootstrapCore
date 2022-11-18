using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc
{
    public interface IBootstrapHelper
    {
        IHtmlHelper HtmlHelper { get; }
    }
}