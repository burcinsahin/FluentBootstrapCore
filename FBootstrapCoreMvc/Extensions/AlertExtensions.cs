using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Extensions
{
    public static class AlertExtensions
    {
        public static BootstrapContent<Alert> Alert(this IBootstrapHelper bootstrapHelper, 
            AlertState alertState = AlertState.Primary, string? heading = null, object? content = null)
        {
            var component = new Alert();
            component.AddCss(alertState.GetCssDescription());
            component.Heading = heading;
            component.Content = content;
            return new BootstrapContent<Alert>(bootstrapHelper.HtmlHelper, component);
        }

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
            var link = new HtmlComponent("a", Css.AlertLink);
            link.AppendContent(content);
            link.MergeAttribute("href", href);
            return new BootstrapContent<HtmlComponent>(builder.HtmlHelper, link);
        }
    }
}
