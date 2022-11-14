using FluentBootstrapCore.Grids;

namespace FluentBootstrapCore.Forms
{
    public class ControlLabel : Tag, IHasGridColumnExtensions, IHasTextContent
    {
        internal ControlLabel(BootstrapHelper helper, object text)
            : base(helper, "label", Css.FormLabel)
        {
            TextContent = text;
        }
    }
}
