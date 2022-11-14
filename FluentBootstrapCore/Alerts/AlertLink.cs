using FluentBootstrapCore.Links;

namespace FluentBootstrapCore.Alerts
{
    public class AlertLink : Tag, IHasTextContent, IHasLinkExtensions
    {
        public AlertLink(BootstrapHelper helper) 
            : base(helper, "a", Css.AlertLink)
        {
        }
    }
}
