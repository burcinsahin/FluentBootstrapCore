using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Table : BootstrapComponent,
        ICanCreate<TableHeader>,
        ICanCreate<TableRow>,
        ICanCreate<TableCell>
    {
        private HtmlElement? _caption;
        public Table(string? caption = null)
            : base("table", Css.Table)
        {
            if (caption != null)
                SetCaption(caption);
        }

        public Table SetStyle(TableStyle tableStyle)
        {
            AddCss(tableStyle.GetCssDescription());
            return this;
        }

        public Table SetResponsive()
        {
            AddCss(Css.TableResponsive);
            return this;
        }

        public Table SetCaption(string caption)
        {
            _caption = new HtmlElement("caption");
            _caption.AppendContent(caption);
            AddChild(_caption);
            return this;
        }
    }
}
