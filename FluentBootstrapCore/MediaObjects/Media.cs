using System.IO;

namespace FluentBootstrapCore.MediaObjects
{
    public class Media : Tag,
        ICanCreate<MediaObject>,
        ICanCreate<MediaBody>
    {
        internal Media(BootstrapHelper helper)
            : base(helper, "div"/*, Css.Media*/)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Change to a list item if inside a MediaList
            if (GetComponent<MediaList>(true) != null)
            {
                TagName = "li";
            }

            base.OnStart(writer);
        }
    }
}
