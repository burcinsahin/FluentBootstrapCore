using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class TableData : Component<TableData>
    {
        public TableData(IHtmlHelper helper, object? content = null)
            : base(helper, "td")
        {
            SetContent(content);
        }
    }
}