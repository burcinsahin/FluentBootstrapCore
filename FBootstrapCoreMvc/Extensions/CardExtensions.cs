
using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FBootstrapCoreMvc.Extensions
{
    public static class CardExtensions
    {
        /// <summary>
        /// Card is new version of old Panel
        /// </summary>
        /// <returns></returns>
        public static BootstrapContent<Card> Card(this IBootstrapHelper bootstrapHelper, string? header = null, string? footer = null)
        {
            var card = new Card();
            if (header != null)
                card.SetHeader(header);
            if (footer != null)
                card.SetFooter(footer);
            return new BootstrapContent<Card>(bootstrapHelper.HtmlHelper, card);
        }

        public static BootstrapContent<TComponent> SetHeader<TComponent>(this BootstrapContent<TComponent> bootstrapContent,
            string? header = null, string? footer = null)
            where TComponent : HtmlComponent
        {
            return bootstrapContent;
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

        public static BootstrapContent<CardBody> Body(this BootstrapBuilder<Card> builder, object? content = null)
        {
            var component = new CardBody
            {
                Content = content
            };
            return new BootstrapContent<CardBody>(builder.HtmlHelper, component);
        }
    }
}
