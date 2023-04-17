using FBootstrapCoreMvc.Components;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Net.Mail;

namespace FBootstrapCoreMvc.Extensions
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
        public static BootstrapContent<TComponent> NoCardBody<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : Card
        {
            bootstrapContent.Component.HasCardBody = false;
            return bootstrapContent;
        }

        public static BootstrapContent<Heading> Title(this BootstrapBuilder<Card> builder, object? content = null)
        {
            var heading = new Heading(5)
            {
                Content = content
            };
            heading.AddCss(Css.CardTitle);
            return new BootstrapContent<Heading>(builder.HtmlHelper, heading);
        }

        public static BootstrapContent<HtmlElement> Text(this BootstrapBuilder<Card> builder, object? content = null)
        {
            var p = new HtmlElement("p")
            {
                Content = content
            };
            p.AddCss(Css.CardText);
            return new BootstrapContent<HtmlElement>(builder.HtmlHelper, p);
        }

        public static BootstrapContent<Image> Image(this BootstrapBuilder<Card> builder, string src, string? alt = null)
        {
            var img = new Image()
            {
                Source = src,
                Alt = alt,
            };
            img.AddCss(Css.CardImg);
            return new BootstrapContent<Image>(builder.HtmlHelper, img);
        }


        public static BootstrapContent<CardHeader> Header(this BootstrapBuilder<Card> builder, object? content = null)
        {
            var component = new CardHeader
            {
                Content = content
            };
            return new BootstrapContent<CardHeader>(builder.HtmlHelper, component);
        }

        public static BootstrapContent<CardFooter> Footer(this BootstrapBuilder<Card> builder, object? content = null)
        {
            var component = new CardFooter
            {
                Content = content
            };
            return new BootstrapContent<CardFooter>(builder.HtmlHelper, component);
        }

        public static BootstrapContent<CardBody> Body(this BootstrapBuilder<Card> builder, object? content = null, string? title = null, string? subtitle = null)
        {
            var cardBody = new CardBody
            {
                Content = content,
                Title = title,
                Subtitle = subtitle
            };
            return new BootstrapContent<CardBody>(builder.HtmlHelper, cardBody);
        }
    }
}
