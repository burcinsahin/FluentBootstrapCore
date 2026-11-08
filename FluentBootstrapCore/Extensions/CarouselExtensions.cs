using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Extensions
{
    public static class CarouselExtensions
    {
        /// <summary>
        /// Creates a carousel item. The first item of the carousel is active automatically.
        /// </summary>
        public static BootstrapContent<CarouselItem> CarouselItem(this ComponentBuilder<Carousel> builder)
        {
            var carousel = builder.Component;
            var carouselItem = new CarouselItem()
            {
                Active = carousel.Items.Count == 0
            };
            carousel.Items.Add(carouselItem);
            return new BootstrapContent<CarouselItem>(builder.HtmlHelper, carouselItem);
        }

        /// <summary>
        /// Creates a carousel item that contains an image (d-block w-100) and, optionally, a caption.
        /// </summary>
        public static BootstrapContent<CarouselItem> CarouselItem(
            this ComponentBuilder<Carousel> builder,
            string src,
            string? alt = null,
            object? captionTitle = null,
            object? captionText = null)
        {
            var content = builder.CarouselItem();
            content.Component.AddChild(CreateImage(src, alt));
            if (captionTitle != null || captionText != null)
                content.Component.AddChild(CreateCaption(captionTitle, captionText));
            return content;
        }

        /// <summary>
        /// Creates an image (d-block w-100) inside a carousel item.
        /// </summary>
        public static BootstrapContent<Image> Image(
            this ComponentBuilder<CarouselItem> builder,
            string src,
            string? alt = null)
        {
            return new BootstrapContent<Image>(builder.HtmlHelper, CreateImage(src, alt));
        }

        /// <summary>
        /// Creates a caption (hidden on small viewports) inside a carousel item.
        /// </summary>
        public static BootstrapContent<CarouselCaption> Caption(
            this ComponentBuilder<CarouselItem> builder,
            object? title = null,
            object? text = null)
        {
            return new BootstrapContent<CarouselCaption>(builder.HtmlHelper, CreateCaption(title, text));
        }

        public static BootstrapContent<Carousel> Ride(
            this BootstrapContent<Carousel> content,
            CarouselRide ride = CarouselRide.OnLoad)
        {
            content.Component.Ride = ride;
            return content;
        }

        /// <summary>
        /// Animates slides with a crossfade instead of a slide.
        /// </summary>
        public static BootstrapContent<Carousel> Fade(
            this BootstrapContent<Carousel> content,
            bool value = true)
        {
            content.Component.Fade = value;
            return content;
        }

        /// <summary>
        /// Enables or disables swiping left/right on touchscreen devices.
        /// </summary>
        public static BootstrapContent<Carousel> Touch(
            this BootstrapContent<Carousel> content,
            bool value = true)
        {
            content.Component.Touch = value;
            return content;
        }

        /// <summary>
        /// Uses darker controls, indicators and captions, for carousels with light slides.
        /// </summary>
        public static BootstrapContent<Carousel> Dark(
            this BootstrapContent<Carousel> content,
            bool value = true)
        {
            content.Component.Dark = value;
            return content;
        }

        /// <summary>
        /// Sets the delay in milliseconds before this item cycles to the next one.
        /// </summary>
        public static BootstrapContent<CarouselItem> Interval(
            this BootstrapContent<CarouselItem> content,
            int milliseconds)
        {
            content.Component.Interval = milliseconds;
            return content;
        }

        /// <summary>
        /// Adds the slide indicators, one per item. The label format is used for aria-label ({0} is the slide number).
        /// </summary>
        public static BootstrapContent<Carousel> Indicators(
            this BootstrapContent<Carousel> content,
            string labelFormat = "Slide {0}")
        {
            content.Component.Indicators = true;
            content.Component.IndicatorLabelFormat = labelFormat;
            return content;
        }

        /// <summary>
        /// Adds the previous/next controls. Texts are for screen readers (visually-hidden).
        /// </summary>
        public static BootstrapContent<Carousel> Controls(
            this BootstrapContent<Carousel> content,
            string previousText = "Previous",
            string nextText = "Next")
        {
            content.Component.Controls = true;
            content.Component.PreviousText = previousText;
            content.Component.NextText = nextText;
            return content;
        }

        private static CarouselCaption CreateCaption(object? title, object? text)
        {
            return new CarouselCaption()
            {
                Title = title,
                Text = text
            };
        }

        private static Image CreateImage(string src, string? alt)
        {
            var image = new Image()
            {
                Source = src,
                Alt = alt
            };
            image.AddCss(Css.DBlock, Css.W100);
            return image;
        }
    }
}
