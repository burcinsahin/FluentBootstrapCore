using FluentBootstrapCore.Html;
using System.IO;

namespace FluentBootstrapCore.Panels
{
    public class PanelBody : PanelSection
    {
        internal PanelBody(BootstrapHelper helper)
            : base(helper/*, Css.PanelBody*/)
        {
        }

        #region Overrides of PanelSection
        protected override void OnStart(TextWriter writer)
        {
            //var accordionPanelGroup = GetComponent<AccordionPanelGroup>();
            //Panel panel = GetComponent<Panel>();
            //if (panel.Collapsible)
            //{
            //    ComponentBuilder<BootstrapConfig, Element> builder = GetHelper().Div()
            //        .AddCss(Css.PanelCollapse, Css.Collapse)
            //        .SetId($"{panel.Id}_collapse");
            //    if (panel.Expanded) builder.Component.AddCss(Css.In);

            //    builder.Component.Start(writer);
            //}
            base.OnStart(writer);
        }
        #endregion
    }
}
