using FluentBootstrapCore.Components;

namespace FluentBootstrapCore.Extensions
{
    public static class FigureExtensions
    {
        /// <summary>
        /// Creates an image with the figure-img class inside a figure.
        /// Chain Fluid(), Border(borderRadius: ...) etc. for img-fluid / rounded.
        /// </summary>
        public static BootstrapContent<Image> Image(
            this ComponentBuilder<Figure> builder,
            string src,
            string? alt = null)
        {
            var img = new Image()
            {
                Source = src,
                Alt = alt
            };
            img.AddCss(Css.FigureImg);
            return new BootstrapContent<Image>(builder.HtmlHelper, img);
        }

        public static BootstrapContent<FigureCaption> Caption(
            this ComponentBuilder<Figure> builder,
            object? content = null)
        {
            var caption = new FigureCaption
            {
                Content = content
            };
            return new BootstrapContent<FigureCaption>(builder.HtmlHelper, caption);
        }
    }
}
