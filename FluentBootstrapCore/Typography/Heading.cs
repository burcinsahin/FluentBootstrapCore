using FluentBootstrapCore.Labels;
using FluentBootstrapCore.ListGroups;
using FluentBootstrapCore.MediaObjects;
using System.IO;

namespace FluentBootstrapCore.Typography
{
    public class Heading : Tag, IHasTextContent,
        ICanCreate<Small>,
        ICanCreate<Label>
    {
        public string SmallText { get; set; }

        internal Heading(BootstrapHelper helper, string tagName)
            : base(helper, tagName)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Add the appropriate CSS class if in a media object
            if (GetComponent<MediaBody>() != null)
            {
                //AddCss(Css.MediaHeading);
            }

            // Add the appropriate CSS class if in a list group item
            if (GetComponent<ListGroupItem>() != null)
            {
                //AddCss(Css.ListGroupItemHeading);
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(SmallText))
            {
                GetHelper().Small().SetText(SmallText).Component.StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }
}
