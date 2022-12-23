using FBootstrapCoreMvc.Components;

namespace FBootstrapCoreMvc.Extensions
{
    public static class AlertExtensions
    {
        public static BootstrapContent<Alert> SetDismissible(this BootstrapContent<Alert> content)
        {
            content.Component.Dismissible = true;
            return content;
        }

        public static BootstrapContent<Alert> SetHeading(this BootstrapContent<Alert> bootstrapContent, object? heading)
        {
            bootstrapContent.Component.Heading = heading?.ToString();
            return bootstrapContent;
        }

        public static BootstrapContent<HtmlComponent> AlertLink(this BootstrapBuilder<Alert> builder, object? content, string? href = "#")
        {
            var link = new HtmlElement("a", Css.AlertLink);
            link.AppendContent(content);
            link.MergeAttribute("href", href);
            return new BootstrapContent<HtmlComponent>(builder.HtmlHelper, link);
        }
    }
}
