using System.ComponentModel;

namespace FluentBootstrapCore
{
    public enum ImageStyle
    {
        [Description()]
        Default,
        //[Description(Css.ImgRounded)]
        //Rounded,
        //[Description(Css.ImgCircle)]
        //Circle,
        [Description(Css.ImgThumbnail)]
        Thumbnail
    }
}
