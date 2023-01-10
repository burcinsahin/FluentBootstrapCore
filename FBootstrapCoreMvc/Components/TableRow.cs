using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class TableRow : SingleComponent,
        ICanCreate<TableData>
    {
        public TableRow() : base("tr")
        {
        }
    }
}