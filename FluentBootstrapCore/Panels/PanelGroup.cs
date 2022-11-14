using System;
using System.IO;

namespace FluentBootstrapCore.Panels
{
    /// <summary>
    /// Component to group panels and add accordion ability if desired
    /// </summary>
    public class PanelGroup : Tag, ICanCreate<Panel>
    {
        internal int PanelCounter { get; set; }
        public bool Accordion { get; set; }

        public PanelGroup(BootstrapHelper helper)
            : base(helper, "div"/*, Css.PanelGroup*/)
        {
        }

        #region Overrides of Tag
        protected override void OnStart(TextWriter writer)
        {
            if (Accordion && string.IsNullOrWhiteSpace(Id))
            {
                GetBuilder(this).SetId($"accordion{DateTime.Now.Ticks}");
            }
            base.OnStart(writer);
        }
        #endregion
    }
}
