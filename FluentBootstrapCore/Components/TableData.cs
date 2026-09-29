using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class TableData(bool headerData = false) : BootstrapComponent(headerData ? "th" : "td"),
        ITableState,
        ICanBeActive
    {
        public int? ColSpan { get; set; }
        public TableState? State { get; set; }
        public bool Active { get; set; }

        protected override void PreBuild()
        {
            if (ColSpan.HasValue)
                MergeAttribute("colspan", ColSpan);

            if (State.HasValue)
                AddCss(State.GetCssDescription());

            if (Active)
                AddCss(Css.TableActive);

            if (Tag == "th")
            {
                if (HasParent<TableHeader>(false))
                    MergeAttribute("scope", "col");
                else if (HasParent<TableRow>(false))
                    MergeAttribute("scope", "row");
            }

            base.PreBuild();
        }
    }
}