using FluentBootstrapCore.Html;
using System.IO;

namespace FluentBootstrapCore.Tables
{
    public class Table : Tag,
        ICanCreate<TableSection>,
        ICanCreate<TableRow>,
        ICanCreate<TableCell>
    {
        private Element _responsiveDiv;

        public bool Responsive { get; set; }

        internal Table(BootstrapHelper helper)
            : base(helper, "table", Css.Table)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            if (Responsive)
            {
                _responsiveDiv = GetHelper().Element("div").AddCss(Css.TableResponsive).Component;
                _responsiveDiv.Start(writer);
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            if (_responsiveDiv != null)
            {
                _responsiveDiv.Finish(writer);
            }
        }
    }
}
