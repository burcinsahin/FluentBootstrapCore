using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Slide of a <see cref="Carousel"/>. Renders a &lt;div class="carousel-item"&gt; element.
    /// The first item of a carousel is active by default; use Active() to override.
    /// </summary>
    public class CarouselItem : BootstrapComponent,
        ICanBeActive,
        ICanCreate<Image>,
        ICanCreate<CarouselCaption>
    {
        public bool Active { get; set; }

        /// <summary>
        /// Delay in milliseconds before cycling to the next item (data-bs-interval).
        /// </summary>
        public int? Interval { get; set; }

        public CarouselItem()
            : base("div", Css.CarouselItem)
        {
        }

        protected override void PreBuild()
        {
            if (Active)
                AddCss(Css.Active);

            if (Interval.HasValue)
                MergeAttribute("data-bs-interval", Interval.Value);

            base.PreBuild();
        }
    }
}
