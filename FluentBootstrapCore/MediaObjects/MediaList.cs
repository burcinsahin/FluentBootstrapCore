namespace FluentBootstrapCore.MediaObjects
{
    public class MediaList : Tag,
        ICanCreate<Media>
    {
        internal MediaList(BootstrapHelper helper)
            : base(helper, "ul"/*, Css.MediaList*/)
        {
        }
    }
}
