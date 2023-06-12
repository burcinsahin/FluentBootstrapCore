using FluentBootstrapCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FluentBootstrapCore.Components
{
    public class TableFooter : BootstrapComponent, ITableData
    {
        public IEnumerable<object>? Data { get; set; }

        public TableFooter() : base("tfoot")
        {
        }

        protected override void PreBuild()
        {
            if (Data != null && Data.Any())
            {
                var tr = new TableRow();
                foreach (var item in Data)
                {
                    var td = new TableData()
                    {
                        Content = item
                    };
                    tr.AddChild(td);
                }
                AddChild(tr);
            }
            base.PreBuild();
        }
    }
}