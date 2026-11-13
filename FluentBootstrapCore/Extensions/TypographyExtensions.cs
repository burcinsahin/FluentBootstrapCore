using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Extensions
{
    public static class TypographyExtensions
    {
        public static BootstrapContent<ListItem> ListItem<TComponent>(this ComponentBuilder<TComponent> builder, object? content = null)
            where TComponent : List
        {
            var listItem = new ListItem() { Content = content };

            if (builder.Component.Type == ListType.Inline)
                listItem.Inline = true;

            return new BootstrapContent<ListItem>(builder.HtmlHelper, listItem);
        }

        public static BootstrapContent<Container> AlignText(this BootstrapContent<Container> content, TextAlign alignment)
        {
            content.Component.AddCss(alignment.GetCssDescription());
            return content;
        }

        #region Image
        public static BootstrapContent<Image> Fluid(this BootstrapContent<Image> content)
        {
            content.Component.Fluid = true;
            return content;
        }

        public static BootstrapContent<Image> Thumbnail(this BootstrapContent<Image> content)
        {
            content.Component.Thumbnail = true;
            return content;
        }
        #endregion
    }
}
