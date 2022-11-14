using System.IO;

namespace FluentBootstrapCore.MediaObjects
{
    public class MediaBody : Tag, IHasTextContent
    {
        public string Heading { get; set; }

        internal MediaBody(BootstrapHelper helper)
            : base(helper, "div"/*, Css.MediaBody*/)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if (!string.IsNullOrWhiteSpace(Heading))
            {
                GetHelper().Heading4(Heading).Component.StartAndFinish(writer);
            }
        }
    }
}
