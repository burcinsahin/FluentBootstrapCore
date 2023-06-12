using System.Collections.Generic;

namespace FluentBootstrapCore.Interfaces
{
    public interface ITableData
    {
        IEnumerable<object>? Data { get; set; }
    }
}
