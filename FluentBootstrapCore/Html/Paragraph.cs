using FluentBootstrapCore.ListGroups;
using System.IO;

namespace FluentBootstrapCore.Html
{
    public class Paragraph : Tag, IHasTextContent
    {
        internal Paragraph(BootstrapHelper helper)
            : base(helper, "p")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Add the appropriate CSS class if in a list group item
            if (GetComponent<ListGroupItem>() != null)
            {
                //AddCss(Css.ListGroupItemText);
            }

            base.OnStart(writer);
        }
    }
}
