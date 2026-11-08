namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Caption of a <see cref="CarouselItem"/>. Renders a &lt;div class="carousel-caption d-none d-md-block"&gt; element,
    /// with an optional &lt;h5&gt; title and &lt;p&gt; text. It is hidden on smaller viewports.
    /// </summary>
    public class CarouselCaption : BootstrapComponent
    {
        public object? Title { get; set; }
        public object? Text { get; set; }

        public CarouselCaption()
            : base("div", Css.CarouselCaption, Css.DNone, Css.DMdBlock)
        {
        }

        protected override void PreBuild()
        {
            if (Title != null)
                AddChild(new Heading(5) { Content = Title });

            if (Text != null)
                AddChild(new HtmlElement("p") { Content = Text });

            base.PreBuild();
        }
    }
}
