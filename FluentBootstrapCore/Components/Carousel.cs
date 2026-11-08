using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;
using System.Collections.Generic;

namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Bootstrap carousel. Renders a &lt;div class="carousel slide"&gt; element with a
    /// &lt;div class="carousel-inner"&gt; wrapper around the <see cref="CarouselItem"/> children.
    /// </summary>
    public class Carousel : BootstrapComponent,
        ICanCreate<CarouselItem>
    {
        public CarouselRide? Ride { get; set; }

        /// <summary>
        /// Animates slides with a fade transition instead of a slide (carousel-fade).
        /// </summary>
        public bool Fade { get; set; }

        /// <summary>
        /// Darker controls, indicators and captions for light backgrounds (carousel-dark).
        /// </summary>
        public bool Dark { get; set; }

        /// <summary>
        /// Whether the carousel supports left/right swipe on touchscreens. Not rendered when null (Bootstrap default is true).
        /// </summary>
        public bool? Touch { get; set; }

        /// <summary>
        /// Renders the slide indicators (one per item). Rendered after the items, which is
        /// visually the same since <c>.carousel-indicators</c> is absolutely positioned.
        /// </summary>
        public bool Indicators { get; set; }
        public string IndicatorLabelFormat { get; set; } = "Slide {0}";

        /// <summary>
        /// Renders the previous/next control buttons after the carousel items.
        /// </summary>
        public bool Controls { get; set; }
        public string PreviousText { get; set; } = "Previous";
        public string NextText { get; set; } = "Next";

        /// <summary>
        /// Items created so far. Used to make the first item active automatically
        /// and to render the indicators.
        /// </summary>
        internal List<CarouselItem> Items { get; } = [];

        public Carousel()
            : base("div", Css.Carousel, "slide")
        {
        }

        protected override void PreBuild()
        {
            if (Id == null)
                GenerateId();

            if (Ride.HasValue)
                MergeAttribute("data-bs-ride", Ride.Value.GetDescription());

            if (Fade)
                AddCss(Css.CarouselFade);

            if (Dark)
                AddCss(Css.CarouselDark);

            if (Touch.HasValue)
                MergeAttribute("data-bs-touch", Touch.Value);

            AddChild(new HtmlElement("div", Css.CarouselInner), ChildLocation.BodyWrap);

            if (Indicators)
                AddChild(new CarouselIndicators(this), ChildLocation.Footer);

            if (Controls)
            {
                AddChild(CreateControl(Css.CarouselControlPrev, Css.CarouselControlPrevIcon, "prev", PreviousText), ChildLocation.Footer);
                AddChild(CreateControl(Css.CarouselControlNext, Css.CarouselControlNextIcon, "next", NextText), ChildLocation.Footer);
            }

            base.PreBuild();
        }

        private HtmlElement CreateControl(string buttonCss, string iconCss, string slide, string text)
        {
            var button = new HtmlElement("button", buttonCss);
            button.MergeAttribute("type", "button");
            button.MergeAttribute("data-bs-target", $"#{Id}");
            button.MergeAttribute("data-bs-slide", slide);

            var icon = new HtmlElement("span", iconCss);
            icon.MergeAttribute("aria-hidden", true);
            button.AddChild(icon);

            button.AddChild(new HtmlElement("span", Css.VisuallyHidden) { Content = text });
            return button;
        }
    }
}
