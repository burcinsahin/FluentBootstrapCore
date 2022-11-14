namespace FluentBootstrapCore.Icons
{
    public class IconSpan : Tag
    {
        internal IconSpan(BootstrapHelper helper, Icon icon)
            : base(helper, "span"/*, Css.Glyphicon*/, icon.GetDescription())
        {
        }
    }
}
