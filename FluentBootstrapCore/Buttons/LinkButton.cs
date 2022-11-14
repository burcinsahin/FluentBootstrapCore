using FluentBootstrapCore.Icons;
using FluentBootstrapCore.Links;

namespace FluentBootstrapCore.Buttons
{
    public class LinkButton : Tag,
        IHasIconExtensions, IHasLinkExtensions, IHasButtonExtensions, IHasButtonStateExtensions, IHasTextContent
    {
        internal LinkButton(BootstrapHelper helper)
            : base(helper, "a", Css.Btn, Css.BtnPrimary)
        {
            MergeAttribute("role", "button");
        }
    }
}
