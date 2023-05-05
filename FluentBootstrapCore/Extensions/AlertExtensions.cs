using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Extensions
{
    public static class AlertExtensions
    {
        public static BootstrapContent<Alert> Dismissible(this BootstrapContent<Alert> content)
        {
            content.Component.Dismissible = true;
            return content;
        }

        public static BootstrapContent<Alert> Heading(this BootstrapContent<Alert> bootstrapContent, object? heading)
        {
            bootstrapContent.Component.Heading = heading?.ToString();
            return bootstrapContent;
        }

        public static BootstrapContent<Alert> Icon(this BootstrapContent<Alert> bootstrapContent, IconType iconType)
        {
            bootstrapContent.Component.IconType = iconType;
            return bootstrapContent;
        }

        public static BootstrapContent<Alert> State(this BootstrapContent<Alert> bootstrapContent, AlertState state)
        {
            bootstrapContent.Component.State = state;
            return bootstrapContent;
        }

        public static BootstrapContent<SingleComponent> AlertLink(this ComponentBuilder<Alert> builder, object? content, string? href = "#")
        {
            var link = new HtmlElement("a", Css.AlertLink);
            link.AppendContent(content);
            link.MergeAttribute("href", href);
            return new BootstrapContent<SingleComponent>(builder.HtmlHelper, link);
        }
    }
}
