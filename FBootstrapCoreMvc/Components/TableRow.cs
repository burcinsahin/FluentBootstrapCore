using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class TableRow : Component<TableRow>,
        ICanCreate<TableData>
    {
        public TableRow(IHtmlHelper helper) : base(helper, "tr")
        {
        }
    }
}