using System.Globalization;

namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Indicators of a <see cref="Carousel"/>. Renders a &lt;div class="carousel-indicators"&gt; element
    /// with one button per carousel item. The buttons are built at render time, so all items
    /// created by then are included and the one that is active is marked as current.
    /// </summary>
    internal class CarouselIndicators : BootstrapComponent
    {
        private readonly Carousel _carousel;

        public CarouselIndicators(Carousel carousel)
            : base("div", Css.CarouselIndicators)
        {
            _carousel = carousel;
        }

        protected override void PreBuild()
        {
            for (var i = 0; i < _carousel.Items.Count; i++)
            {
                var button = new HtmlElement("button");
                button.MergeAttribute("type", "button");
                button.MergeAttribute("data-bs-target", $"#{_carousel.Id}");
                button.MergeAttribute("data-bs-slide-to", i.ToString(CultureInfo.InvariantCulture));
                if (_carousel.Items[i].Active)
                {
                    button.AddCss(Css.Active);
                    button.MergeAttribute("aria-current", true);
                }
                button.MergeAttribute("aria-label", string.Format(CultureInfo.CurrentCulture, _carousel.IndicatorLabelFormat, i + 1));
                AddChild(button);
            }

            base.PreBuild();
        }
    }
}
