using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class TableRow : BootstrapComponent,
        ICanCreate<TableData>
    {
        public TableRow() : base("tr")
        {
        }
    }
}