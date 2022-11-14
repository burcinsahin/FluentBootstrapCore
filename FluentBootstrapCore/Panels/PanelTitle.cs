using FluentBootstrapCore.Links;
using System;
using System.IO;

namespace FluentBootstrapCore.Panels
{
    public class PanelTitle : Tag, IHasTextContent, ICanCreate<Link>
    {
        internal PanelTitle(BootstrapHelper helper, object text, int headingLevel)
            : base(helper, "h" + headingLevel/*, Css.PanelTitle*/)
        {
            if (headingLevel < 1 || headingLevel > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(headingLevel));
            }
            TextContent = text;
        }

        protected override void OnStart(TextWriter writer)
        {
            // Make sure we're in a PanelHeading
            if (GetComponent<PanelHeading>() == null)
            {
                GetHelper().PanelHeading().Component.Start(writer);
            }

            Panel panel = GetComponent<Panel>();
            if (panel != null && panel.Collapsible)
            {
                ComponentBuilder<BootstrapConfig, Link> link = GetHelper()
                    .Link(TextContent, $"#{panel.Id}_collapse")
                    .AddAttribute("data-toggle", "collapse");

                PanelGroup panelGroup = GetComponent<PanelGroup>();
                if (panelGroup != null && panelGroup.Accordion)
                {
                    link.AddAttribute("data-parent", $"#{panelGroup.Id}");
                }

                AddChild(link);
                TextContent = null;
            }

            base.OnStart(writer);
        }
    }
}