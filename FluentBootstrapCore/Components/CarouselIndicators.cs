using System.Globalization;

namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Indicators of a <see cref="Carousel"/>. Renders a &lt;div class="carousel-indicators"&gt; element
    /// with one button per carousel item. The buttons are built at render time, so all items
    /// created by then are included and the one that is active is marked as current.
    /// </summary>
    internal class CarouselIndicators(Carousel carousel)
        : BootstrapComponent("div", Css.CarouselIndicators)
    {
        protected override void PreBuild()
        {
            for (var i = 0; i < carousel.Items.Count; i++)
            {
                var button = new HtmlElement("button");
                button.MergeAttribute("type", "button");
                button.MergeAttribute("data-bs-target", $"#{carousel.Id}");
                button.MergeAttribute("data-bs-slide-to", i.ToString(CultureInfo.InvariantCulture));
                if (carousel.Items[i].Active)
                {
                    button.AddCss(Css.Active);
                    button.MergeAttribute("aria-current", true);
                }
                button.MergeAttribute("aria-label", string.Format(CultureInfo.CurrentCulture, carousel.IndicatorLabelFormat, i + 1));
                AddChild(button);
            }

            base.PreBuild();
        }
    }
}
