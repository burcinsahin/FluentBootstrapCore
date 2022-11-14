using FluentBootstrapCore.ListGroups;
using System;
using System.IO;

namespace FluentBootstrapCore.Panels
{
    public class Panel : Tag,
        ICanCreate<PanelSection>,
        ICanCreate<PanelTitle>,
        ICanCreate<ListGroup>
    {
        public bool Expanded { get; set; }
        public bool Collapsible { get; set; }

        internal Panel(BootstrapHelper helper)
            : base(helper, "div"/*, Css.Panel, Css.PanelDefault*/)
        {
        }

        #region Overrides of Tag
        protected override void OnStart(TextWriter writer)
        {
            PanelGroup panelGroup = GetComponent<PanelGroup>();
            if (panelGroup != null)
            {
                if (panelGroup.Accordion)
                {
                    Collapsible = true;
                    if (string.IsNullOrWhiteSpace(Id))
                        Id = $"{panelGroup.Id}_panel{panelGroup.PanelCounter}";
                }
                panelGroup.PanelCounter++;
            }
            else if (Collapsible)
            {
                if (string.IsNullOrWhiteSpace(Id))
                    Id = $"panel{DateTime.Now.Ticks}";
            }
            base.OnStart(writer);
        }
        #endregion
    }
}
