using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FluentBootstrapCore.Components
{
    public class TableRow : BootstrapComponent,
        ICanCreate<TableData>,
        ITableState,
        ICanBeActive,
        ITableData
    {
        public TableState? State { get; set; }
        public IEnumerable<object>? Data { get; set; }
        public bool Active { get; set; }

        public TableRow() : base("tr")
        {
        }

        protected override void PreBuild()
        {
            if (State.HasValue)
                AddCss(State.GetCssDescription());

            if (Active)
                AddCss(Css.TableActive);

            if (Data?.Any() == true)
            {
                for (var i = 0; i < Data.Count(); i++)
                {
                    AddChild(new TableData(i == 0) { Content = Data.ElementAt(i) });
                }
            }

            base.PreBuild();
        }
    }
}