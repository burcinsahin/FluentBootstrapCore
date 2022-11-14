using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluentBootstrapCore.Tests.Mvc.Workshop
{
    public class MyDiv : TagBuilder
    {
        public MyDiv(string? text = null)
            : base("div")
        {
            if (!string.IsNullOrEmpty(text))
            {
                InnerHtml.Append(text);
            }
        }
    }
}
