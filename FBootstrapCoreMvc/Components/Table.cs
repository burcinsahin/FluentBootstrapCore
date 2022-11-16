using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Table : Component<Table>,
        ICanCreate<TableHeader>,
        ICanCreate<TableRow>,
        ICanCreate<TableCell>
    {
        private Component _caption;
        public Table(IHtmlHelper helper, string? caption = null)
            : base(helper, "table", Css.Table)
        {
            if (caption != null)
                SetCaption(caption);
        }

        public Table SetStyle(TableStyle tableStyle) => AddCss(tableStyle.GetCssDescription());

        public Table SetResponsive() => AddCss(Css.TableResponsive);

        public Table SetCaption(string caption)
        {
            _caption = new Component(_helper, "caption");
            _caption.InnerHtml.SetContent(caption);
            InnerHtml.SetHtmlContent(_caption);
            return this;
        }
    }
}
