using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace FBootstrapCoreMvc.Components
{
    public class TableHeader : SingleComponent
    {
        public TableHeader(params string[] headers) : base("thead")
        {
            if (headers.Any())
            {
                var tr = new TagBuilder("tr");
                foreach (var header in headers)
                {
                    var th = new TagBuilder("th");
                    th.MergeAttribute("scope", "col");
                    th.InnerHtml.SetContent(header);
                    tr.InnerHtml.AppendHtml(th);
                }
                AppendContent(tr);
            }
        }
    }
}