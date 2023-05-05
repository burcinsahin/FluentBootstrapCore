using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Extensions
{
    public static class CardExtensions
    {
        public static BootstrapContent<TComponent> Header<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string header, bool collapsible = false)
            where TComponent : Card
        {
            bootstrapContent.Component.Header = header;
            bootstrapContent.Component.Collapsible = collapsible;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Title<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string title)
            where TComponent : Card
        {
            bootstrapContent.Component.BodyTitle = title;
            return bootstrapContent;
        }

        /// <summary>
        /// Skips rendering card body. Use if you will manually add cardbody component.
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="bootstrapContent"></param>
        /// <returns></returns>
        public static BootstrapContent<TComponent> CustomBody<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool value = true)
            where TComponent : Card
        {
            bootstrapContent.Component.CustomBody = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> BodyColor<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            TextColor bodyColor)
            where TComponent : Card
        {
            bootstrapContent.Component.BodyColor = bodyColor;
            return bootstrapContent;
        }

        public static BootstrapContent<Heading> Title(
            this ComponentBuilder<Card> builder,
            object? content = null)
        {
            var heading = new Heading(5)
            {
                Content = content
            };
            heading.AddCss(Css.CardTitle);
            return new BootstrapContent<Heading>(builder.HtmlHelper, heading);
        }

        public static BootstrapContent<Heading> Subtitle(
            this ComponentBuilder<Card> builder,
            object? content = null)
        {
            var heading = new Heading(6)
            {
                Content = content
            };
            heading.AddCss(Css.CardSubtitle, Css.TextMuted);
            return new BootstrapContent<Heading>(builder.HtmlHelper, heading);
        }

        public static BootstrapContent<HtmlElement> Text(
            this ComponentBuilder<Card> builder,
            object? content = null)
        {
            var p = new HtmlElement("p")
            {
                Content = content
            };
            p.AddCss(Css.CardText);
            return new BootstrapContent<HtmlElement>(builder.HtmlHelper, p);
        }

        public static BootstrapContent<Link> Link(
            this ComponentBuilder<Card> builder,
            object? content = null,
            string href = "#")
        {
            var p = new Link()
            {
                Content = content,
                Href = href
            };
            p.AddCss(Css.CardLink);
            return new BootstrapContent<Link>(builder.HtmlHelper, p);
        }

        public static BootstrapContent<Image> Image(
            this ComponentBuilder<Card> builder,
            string src,
            string? alt = null,
            CardImage? cardImage = null)
        {
            var img = new Image()
            {
                Source = src,
                Alt = alt,
            };
            if (cardImage.HasValue)
                img.AddCss(cardImage.GetCssDescription());
            else
                img.AddCss(Css.CardImg);

            return new BootstrapContent<Image>(builder.HtmlHelper, img);
        }

        public static BootstrapContent<HtmlElement> ImageOverlay(this ComponentBuilder<Card> builder)
        {
            var div = new HtmlElement("div", Css.CardImgOverlay);
            return new BootstrapContent<HtmlElement>(builder.HtmlHelper, div);
        }

        public static BootstrapContent<CardHeader> Header(
            this ComponentBuilder<Card> builder,
            object? content = null)
        {
            var component = new CardHeader
            {
                Content = content
            };
            return new BootstrapContent<CardHeader>(builder.HtmlHelper, component);
        }

        public static BootstrapContent<CardFooter> Footer(
            this ComponentBuilder<Card> builder,
            object? content = null)
        {
            var component = new CardFooter
            {
                Content = content
            };
            return new BootstrapContent<CardFooter>(builder.HtmlHelper, component);
        }

        public static BootstrapContent<CardBody> Body(
            this ComponentBuilder<Card> builder,
            object? content = null,
            string? title = null,
            string? subtitle = null)
        {
            var cardBody = new CardBody
            {
                Content = content,
                Title = title,
                Subtitle = subtitle
            };
            //builder.Component.CardBodyList.Add(cardBody);
            return new BootstrapContent<CardBody>(builder.HtmlHelper, cardBody);
        }

        public static BootstrapContent<Card> Card(this ComponentBuilder<CardGroup> builder)
        {
            var card = new Card();
            return new BootstrapContent<Card>(builder.HtmlHelper, card);
        }
    }
}
