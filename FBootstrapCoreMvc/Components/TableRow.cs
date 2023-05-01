using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class TableRow : BootstrapComponent,
        ICanCreate<TableData>
    {
        public TableRow() : base("tr")
        {
        }
    }
}