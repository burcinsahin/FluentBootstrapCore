using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;
using System.Linq;

namespace FluentBootstrapCore.Components
{
    public class Table : BootstrapComponent,
        ICanCreate<TableHeader>,
        ICanCreate<TableRow>,
        ICanCreate<TableData>,
        ICanCreate<TableBody>,
        ITableState
    {
        public object? Caption { get; set; }
        public bool CaptionTop { get; set; }
        public TableStyle? Style { get; set; }
        public TableState? State { get; set; }
        public Breakpoint? Responsive { get; set; }
        public bool Hover { get; set; }
        public bool Small { get; set; }

        public Table()
            : base("div")
        {
        }

        protected override void PreBuild()
        {
            if (Responsive.HasValue)
                AddCss(Css.TableResponsive + Responsive.Value.GetHyphenatedDescription());

            var table = new HtmlElement("table", Css.Table);
            
            if (UtilityOptions.Any())
            {
                foreach (var opt in UtilityOptions)
                {
                    table.UtilityOptions.Add(opt);
                }
                UtilityOptions.Clear();
            }

            if (Style.HasValue)
                table.AddCss(Style.GetCssDescription());

            if (State.HasValue)
                table.AddCss(State.GetCssDescription());

            if (Hover)
                table.AddCss(Css.TableHover);

            if (Small)
                table.AddCss(Css.TableSm);

            if (Caption != null)
            {
                var caption = new HtmlElement("caption") { Content = Caption };
                AddChild(caption, ChildLocation.Header);
                if (CaptionTop)
                    table.AddCss(Css.CaptionTop);
            }
            AddChild(table, ChildLocation.FullWrap);

            base.PreBuild();
        }
    }
}
