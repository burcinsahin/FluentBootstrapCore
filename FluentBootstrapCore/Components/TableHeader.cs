using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FluentBootstrapCore.Components
{
    public class TableHeader : BootstrapComponent,
        ITableState,
        ITableData
    {
        public IEnumerable<object>? Data { get; set; }
        public TableState? State { get; set; }

        public TableHeader() : base("thead")
        {
        }

        protected override void PreBuild()
        {
            if (State.HasValue)
                AddCss(State.GetCssDescription());

            if (Data != null && Data.Any())
            {
                var tr = new TableRow();
                foreach (var header in Data)
                {
                    var th = new TableData(true)
                    {
                        Content = header
                    };
                    tr.AddChild(th);
                }
                AddChild(tr);
            }
            base.PreBuild();
        }
    }
}