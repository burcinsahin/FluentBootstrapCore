using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class TableRow : HtmlComponent,
        ICanCreate<TableData>
    {
        public TableRow() : base("tr")
        {
        }
    }
}